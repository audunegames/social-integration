namespace Audune.Social
{
  /// <summary>
  /// Enum that defines the type of relationship between two users.
  /// </summary>
  public enum RelationshipType
  {
    None,
    Friend,
    IncomingFriendRequest,
    OutgoingFriendRequest,
    Blocked,
    Unknown,
  }
}
