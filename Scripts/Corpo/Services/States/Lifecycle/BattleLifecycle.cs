using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screens.Core;

using Godot;


namespace Corpo.Services.States.Lifecycle;

public class BattleLifecycle : IStateLifecycle {
  private readonly EnvironmentService environmentService;
  private readonly ScreenService screenService;

  public BattleLifecycle(
    EnvironmentService environmentService,
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.screenService = screenService;
  }

  public void OnSetUp() {
    // TODO(shoegaze): Create from NodeService.GetBaseScreen(bool cache = true)
    var battleScene = GD.Load<PackedScene>(
      environmentService.Environment.Path.Screen.Battle);

    global::Corpo.Screens.Core.Screen battleScreen = battleScene.Instantiate<BattleScreen>();

    screenService.Enter(battleScreen);
  }

  public void OnTearDown() {
    // TODO(shoegaze)
  }
}
