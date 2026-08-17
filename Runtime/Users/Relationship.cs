using System;

namespace Audune.Social
{
  /// <summary>
  /// Class that defines a relationship between two users.
  /// </summary>
  public sealed class Relationship : IEquatable<Relationship>
  {
    /// <summary>
    /// The user that is in a relationship with the current user.
    /// </summary>
    public readonly IUser user;
    
    /// <summary>
    /// The relationship that the user has towards the current user.
    /// </summary>
    public readonly RelationshipType relationshipType;


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="user">The user that is in a relationship with the current user.</param>
    /// <param name="relationshipType">The relationship that the user has towards the current user.</param>
    public Relationship(IUser user, RelationshipType relationshipType)
    {
      this.user = user;
      this.relationshipType = relationshipType;
    }

    
    #region Equatable implementation
    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
      return ReferenceEquals(this, obj) 
        || obj is Relationship other && Equals(other);
    }
    
    /// <inheritdoc/>
    public bool Equals(Relationship other)
    {
      if (other is null)
        return false;
      if (ReferenceEquals(this, other))
        return true;
      return Equals(user, other.user) && relationshipType == other.relationshipType;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
      return HashCode.Combine(user, (int)relationshipType);
    }

    
    /// <summary>
    /// Returns if the specified user relationships equal each other.
    /// </summary>
    /// <param name="left">The left user relationship to check.</param>
    /// <param name="right">The right user relationship to check.</param>
    /// <returns>If the specified user relationships equal each other.</returns>
    public static bool operator ==(Relationship left, Relationship right)
    {
      return Equals(left, right);
    }

    /// <summary>
    /// Returns if the specified user relationships do not equal each other.
    /// </summary>
    /// <param name="left">The left user relationship to check.</param>
    /// <param name="right">The right user relationship to check.</param>
    /// <returns>If the specified user relationships do not equal each other.</returns>
    public static bool operator !=(Relationship left, Relationship right)
    {
      return !(left == right);
    }
    #endregion
  }
}
