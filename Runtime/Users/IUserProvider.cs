using Cysharp.Threading.Tasks;

namespace Audune.Social
{
  /// <summary>
  /// Interface that defines a provider that returns the current user.
  /// </summary>
  public interface IUserProvider
  {
    /// <summary>
    /// Returns the current user of the social provider.
    /// </summary>
    public UniTask<IUser> GetCurrentUser();
  }
}
