using System;
using System.Collections.Generic;

namespace Audune.Social
{
  /// <summary>
  /// Class that defines a comparer that compares users based on how they will be displayed.
  /// USers playing this game are sorted first, then users playing another game, then other users ordered by their status and display name.
  /// </summary>
  public sealed class UserDisplayComparer : IComparer<IUser>
  {
    /// <inheritdoc/>
    public int Compare(IUser a, IUser b)
    {
      if (ReferenceEquals(a, b))
        return 0;
      if (a == null)
        return 1;
      if (b == null)
        return -1;

      var isPlayingThisGameComparison = a.isPlaying.CompareTo(b.isPlayingThisGame);
      if (isPlayingThisGameComparison != 0)
        return -isPlayingThisGameComparison;
      
      var isPlayingComparison = a.isPlaying.CompareTo(b.isPlaying);
      if (isPlayingComparison != 0)
        return -isPlayingComparison;

      var statusComparison = a.status.CompareTo(b.status);
      if (statusComparison != 0)
        return statusComparison;
      
      return string.Compare(a.displayName, b.displayName, StringComparison.OrdinalIgnoreCase);
    }
  }
}
