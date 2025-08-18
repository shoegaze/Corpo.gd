using Corpo.Base;
using Corpo.Core.Nodes;
using Corpo.Core.Screens;

using Godot;

using TeamSports.Logging;
using TeamSports.Services.Game;


namespace Corpo.Core.Game._Impl;


// ReSharper disable once UnusedType.Global
public sealed class GameService(
  ILogger logger,
  INodeService nodeService
) : IGameService {

  public void StartGame() {
    logger.Info("Starting game...");

    Main.BaseContainer.GetInstance<IScreenService>()
     .EnterScreen<IBaseScreen>(focusImmediately: true);
  }

  public void ExitGame() {
    logger.Info("Exiting game...");

    // TODO?: Manually dispose services

    QuitGodot(nodeService.RootContainer);
  }

  private static void QuitGodot(Node mainNode) {
    SceneTree sceneTree = mainNode.GetTree();

    sceneTree
     .Root
     .PropagateNotification((int)Node.NotificationWMCloseRequest);

    sceneTree.Quit();
  }
}
