namespace Audune.Social
{
  /// <summary>
  /// Delegate for when a game overlay is activated.
  /// </summary>
  /// <param name="provider">The game overlay provider whose game overlay has been activated.</param>
  /// <param name="isActive">The active state of the game overlay.</param>
  public delegate void GameOverlayActivatedEvent(IGameOverlayProvider provider, bool isActive);
}
