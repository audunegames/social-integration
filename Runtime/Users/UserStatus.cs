namespace Audune.Social
{
  /// <summary>
  /// Enum that defines the status of a user in a social provider.
  /// </summary>
  public enum UserStatus
  {
    /// <summary>
    /// The user is online and recently active.
    /// </summary>
    Online,
    
    /// <summary>
    /// The user is online, but has not been active for a while and may be away from their computer. 
    /// </summary>
    Idle,
    
    /// <summary>
    /// The user is online, but wishes to suppress notifications for the time being.
    /// </summary>
    DoNotDisturb,
    
    /// <summary>
    /// The user is offline.
    /// </summary>
    Offline,
    
    /// <summary>
    /// The status of the user is not known.
    /// </summary>
    Unknown,
  }
}
