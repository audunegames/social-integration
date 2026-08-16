namespace Audune.Social
{
  /// <summary>
  /// Interface that defines a provider for listening to game overlay events
  /// </summary>
  public interface IGameOverlayProvider
  {
    /// <summary>
    /// Event that is invoked when the game overlay has been activated.
    /// </summary>
    public event GameOverlayActivatedEvent onGameOverlayActivated;
  }
}
