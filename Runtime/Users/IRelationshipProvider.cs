using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Audune.Social
{
  /// <summary>
  /// Interface that defines a provider that returns the relationships of the current user.
  /// </summary>
  public interface IRelationshipProvider : IUserProvider
  {
    /// <summary>
    /// Returns the relationships of the current user.
    /// </summary>
    /// <returns>The relationships of the current user.</returns>
    public UniTask<IReadOnlyCollection<Relationship>> GetCurrentUserRelationships();

    /// <summary>
    /// Returns the type of relationship between the current user and the specified user.
    /// </summary>
    /// <param name="otherUser">The other user to get the type of relationship for.</param>
    /// <returns>The type of relationship between the current user and the specified user.</returns>
    public UniTask<RelationshipType> GetCurrentUserRelationshipType(IUser otherUser);
  }
}
