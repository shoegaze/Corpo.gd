using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Logging;

using TeamSports.Adapters.Godot.App.Concrete;
using TeamSports.Adapters.Godot.App.Helpers;
using TeamSports.Core.App.Models;


namespace Corpo._App;


public sealed class
  CorpoEventHandler : DefaultGodotEventHandler<CorpoApp, CorpoUserInput> {
  private ILogger logger = null!;

  public override void Start(CorpoApp gameApp, AppStartContext ctx) {
    logger = gameApp.Logger;

    logger.Info("Starting game...");

    // Main.ServicesContainer.GetInstance<IScreenService>()
    //  .EnterScreen<IBaseScreen>(focusImmediately: true);
  }

  public override void Exit(CorpoApp gameApp) {
    logger.Info("Exiting game...");

    // TODO: Dispose services

    GodotEventHelper.CloseGodot(gameApp.RootNode);
  }

  public override AppTickResult Tick(
    CorpoApp gameApp,
    double dt,
    CorpoUserInput userInput
  ) {
    return AppTickResult.Ok;
  }
}
