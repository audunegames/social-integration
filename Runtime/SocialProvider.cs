using UnityEngine;

namespace Audune.Social
{
  /// <summary>
  /// Class that defines a social provider.
  /// </summary>
  [RequireComponent(typeof(SocialSystem))]
  public abstract class SocialProvider : MonoBehaviour
  {
    // Internal state
    private SocialSystem _socialSystem;
    
    
    /// <summary>
    /// Returns the social system this social provider is connected to.
    /// </summary>
    public SocialSystem socialSystem => _socialSystem;
    
    /// <summary>
    /// Returns if the social provider is initialized.
    /// </summary>
    public abstract bool isInitialized { get; }
    
    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    protected virtual void Awake()
    {
      // Resolve the references
      _socialSystem = GetComponent<SocialSystem>();
    }


    /// <summary>
    /// OnEnableSocialProvider is called when the social provider is being initialized by the social system.
    /// </summary>
    public virtual void OnEnableSocialProvider()
    {
    }

    /// <summary>
    /// OnDisableSocialProvider is called when the social provider is being disposed of by the social system
    /// </summary>
    public virtual void OnDisableSocialProvider()
    {
    }

    /// <summary>
    /// OnUpdateSocialProvider is called once per frame
    /// </summary>
    public virtual void OnUpdateSocialProvider()
    {
    }
  }
}
