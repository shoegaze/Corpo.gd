using Corpo.Adapters.TeamSports.Game;
using Corpo.Adapters.TeamSports.Game.Models;
using Corpo.Adapters.TeamSports.Logging;
using Corpo.Base;
using Corpo.Core.Node;
using Corpo.Core.Screens;


namespace Corpo.Core.Game._Impl;


// ReSharper disable once UnusedType.Global
public sealed class GameService(
  ICorpoLogger logger,
  INodeService nodeService
) : ICorpoGameService {

  public void StartGame(CorpoStartContext ctx) {
    logger.Info("Starting game...");

    Main.ServicesContainer.GetInstance<IScreenService>()
     .EnterScreen<IBaseScreen>(focusImmediately: true);
  }

  public void ExitGame() {
    logger.Info("Exiting game...");

    // TODO?: Manually dispose services

    QuitGodot(nodeService.RootContainer);
  }

  private static void QuitGodot(Godot.Node mainNode) {
    var sceneTree = mainNode.GetTree();

    sceneTree
     .Root
     .PropagateNotification((int)Godot.Node.NotificationWMCloseRequest);

    sceneTree.Quit();
  }
}
