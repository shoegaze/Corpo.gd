using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.Base.States;

using Godot;


namespace Corpo.Battle;


public class BattleLifecycle(
  IEnvironmentService environmentService,
  IScreenService screenService
) : IStateLifecycle {
  public void OnSetUp() {
    // TODO: Create from NodeService.GetBaseScreen(bool cache = true)
    var battleScene =
        GD.Load<PackedScene>(
              environmentService.Environment.Path.Screen.Battle
            );

    GodotScreen battleScreen = battleScene.Instantiate<BattleScreen>();

    screenService.Enter(battleScreen);
  }

  public void OnTearDown() {
    // TODO
  }
}
