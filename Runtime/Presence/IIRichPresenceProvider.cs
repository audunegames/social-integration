namespace Audune.Social
{
  /// <summary>
  /// Interface that defines a provider for updating the rich presence.
  /// </summary>
  public interface IIRichPresenceProvider
  {
    /// <summary>
    /// Updates the rich presence to the specified activity data.
    /// </summary>
    /// <param name="data">The rich presence data to display.</param>
    public void UpdateRichPresence(IRichPresenceData data);
    
    /// <summary>
    /// Clears the rich presence.
    /// </summary>
    public void ClearRichPresence();
  }
}
