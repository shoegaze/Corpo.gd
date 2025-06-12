using Godot;

using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screens;


namespace Corpo.Services.States.Lifecycle;


public class BattleLifecycle(
  EnvironmentService environmentService,
  ScreenService screenService
)
    : IStateLifecycle {
  private readonly ScreenService screenService = screenService;

  public void OnSetUp() {
    // TODO(shoegaze): Create from NodeService.GetBaseScreen(bool cache = true)
    var battleScene =
        GD.Load<PackedScene>(
              environmentService.Environment.Path.Screen.Battle
            );

    GodotScreen battleScreen = battleScene.Instantiate<BattleScreen>();

    screenService.Enter(battleScreen);
  }

  public void OnTearDown() {
    // TODO(shoegaze)
  }
}
