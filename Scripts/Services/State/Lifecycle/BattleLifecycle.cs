using Corpo.Scripts.Screens;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts.Services.State.Lifecycle; 

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
    // TODO(spike): Create from NodeService.GetBaseScreen(bool cache = true)
    PackedScene battleScene = GD.Load<PackedScene>(
      environmentService.Environment.Paths.Screens.Battle);
    Screens.Core.Screen battleScreen = battleScene.Instantiate<BattleScreen>();
    
    screenService.Enter(battleScreen);
  }
  
  public void OnTearDown() {
    // TODO(spike)
  }
}
