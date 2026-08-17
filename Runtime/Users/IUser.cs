using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Audune.Social
{
  /// <summary>
  /// Interface that defines a user in a social provider.
  /// </summary>
  public interface IUser : IEquatable<IUser>
  {
    /// <summary>
    /// Returns the source social provider of the user.
    /// </summary>
    public SocialProvider socialProvider { get; }
    
    /// <summary>
    /// Returns the name of the user. This is more than often the internal name of the user and should not be used to display information about the user.
    /// </summary>
    public string name { get; }
    
    /// <summary>
    /// Returns the display name of the user. This should be used to display information about the user.
    /// </summary>
    public string displayName { get; }
    
    /// <summary>
    /// Returns the status of the user.
    /// </summary>
    public UserStatus status { get; }
    
    /// <summary>
    /// Returns if the user is currently in a game.
    /// </summary>
    public bool isPlaying { get; }
    
    /// <summary>
    /// Returns if the user is currently in this game.
    /// </summary>
    public bool isPlayingThisGame { get; }
    
    
    /// <summary>
    /// Returns the avatar of the user and invoke the specified callback upon completion.
    /// </summary>
    /// <param name="size">The desired size in pixels of the avatar; defaults to 1024.</param>
    /// <param name="cancellationToken">The cancellation token for the web request.</param>
    public UniTask<Texture2D> GetAvatar(int size = 1024, CancellationToken cancellationToken = default);
  }
}
