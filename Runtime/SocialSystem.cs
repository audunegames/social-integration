using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Audune.Social
{
  /// <summary>
  /// Class that defines the social system.
  /// </summary>
  [AddComponentMenu("Audune/Social/Social System")]
  [DefaultExecutionOrder(10)]
  public sealed class SocialSystem : MonoBehaviour,
    IUserProvider,
    IIRichPresenceProvider,
    IGameOverlayProvider
  {
    // Static variables
    private static SocialSystem _current;

    /// <summary>
    /// Returns the static instance of the social system.
    /// </summary>
    public static SocialSystem current => _current;
    
    
    // Internal state
    private readonly List<SocialProvider> _initializedSocialProviders = new List<SocialProvider>();
    
    
    /// <summary>
    /// Returns all social providers of the system.
    /// </summary>
    public IEnumerable<SocialProvider> socialProviders => GetComponents<SocialProvider>()
      .OrderBy(socialProvider => socialProvider.priority);


    /// <summary>
    /// Returns the enabled social providers of the system.
    /// </summary>
    public IEnumerable<SocialProvider> enabledSocialProviders => socialProviders
      .Where(socialProvider => socialProvider.executionMode.ShouldExecute());

    /// <summary>
    /// Returns the initialized social providers of the system.
    /// </summary>
    public IEnumerable<SocialProvider> initializedSocialProviders => _initializedSocialProviders;
    
    /// <summary>
    /// Returns if any of the social providers of the system are initialized.
    /// </summary>
    public bool isInitialized => initializedSocialProviders.Any();
    
    
    /// <summary>
    /// Event that is invoked when a social provider has been initialized.
    /// </summary>
    public event SocialProviderInitializedEvent onSocialProviderInitialized;
    
    /// <inheritdoc/>
    public event GameOverlayActivatedEvent onGameOverlayActivated;
    
    
    // Awake event
    private void Awake()
    {
      // Set the static instance
      if (_current == null)
        _current = this;
      else
        Destroy(gameObject);
    }
    
    // OnEnable event
    private void OnEnable()
    {
      // Iterate over the enabled social providers
      foreach (var socialProvider in enabledSocialProviders)
      {
        // Enable the social provider
        socialProvider.OnEnableSocialProvider();
        
        // Add event handlers
        if (socialProvider is IGameOverlayProvider gameOverlayProvider)
          gameOverlayProvider.onGameOverlayActivated += OnGameOverlayActivated;
      }
    }
    
    // OnDisable event 
    private void OnDisable()
    {      
      // Iterate over the enabled social providers
      foreach (var socialProvider in enabledSocialProviders)
      {
        // Disable the social provider
        socialProvider.OnDisableSocialProvider();
        
        // Remove event handlers
        if (socialProvider is IGameOverlayProvider gameOverlayProvider)
          gameOverlayProvider.onGameOverlayActivated -= OnGameOverlayActivated;
      }
    }
    
    
    #region Updating the behaviour
    // Update event
    private void Update()
    {
      // Iterate over the enabled social providers
      foreach (var socialProvider in enabledSocialProviders)
      {
        // Check if the social provider is initialized
        if (socialProvider.isInitialized)
        {
          // Check if the social provider just has been initialized
          if (!_initializedSocialProviders.Contains(socialProvider))
          {
            // Add the social provider to the initialized social providers
            _initializedSocialProviders.Add(socialProvider);

            // Invoke the social provider initialized event
            onSocialProviderInitialized?.Invoke(socialProvider);
          }

          // Update the social provider
          socialProvider.OnUpdateSocialProvider();
        }
      }
    }
    #endregion
    
    #region User provider implementation
    /// <summary>
    /// Returns all current users from the social providers that support it.
    /// </summary>
    /// <returns>All current users from the social providers that support it.</returns>
    public async UniTask<IEnumerable<IUser>> GetCurrentUsers()
    {
      var currentUsers = await UniTask.WhenAll(initializedSocialProviders.OfType<IUserProvider>()
        .Select(socialProvider => socialProvider.GetCurrentUser()));
      return currentUsers.Where(user => user != null);
    }
    
    /// <inheritdoc/>
    public async UniTask<IUser> GetCurrentUser()
    {
      var currentUsers = await GetCurrentUsers();
      return currentUsers.FirstOrDefault();
    }
    #endregion
    
    #region Rich presence provider implementation
    /// <inheritdoc/>
    public void UpdateRichPresence(IRichPresenceData data)
    {
      // Iterate over the initialized social providers and update the rich presence if it is a rich presence provider
      foreach (var socialProvider in initializedSocialProviders.OfType<IIRichPresenceProvider>())
        socialProvider.UpdateRichPresence(data);
    }
    
    /// <inheritdoc/>
    public void ClearRichPresence()
    {
      // Iterate over the initialized social providers and clear the rich presence if it is a rich presence provider
      foreach (var socialProvider in initializedSocialProviders.OfType<IIRichPresenceProvider>())
        socialProvider.ClearRichPresence();
    }
    #endregion
    
    #region Event handlers
    // Social provider initialized handler
    private void OnSocialProviderInitialized(SocialProvider socialProvider)
    {
      onSocialProviderInitialized?.Invoke(socialProvider);
    }
    
    // Game overlay activated handler
    private void OnGameOverlayActivated(IGameOverlayProvider provider, bool isActive)
    {
      onGameOverlayActivated?.Invoke(provider, isActive);
    }
    #endregion
  }
}
