using Corpo.Scripts.Screens;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts.Services.State.Lifecycle; 

public class BaseLifecycle : IStateLifecycle {
  private readonly EnvironmentService environmentService;
  private readonly ScreenService screenService;
  
  public BaseLifecycle(
    EnvironmentService environmentService, 
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.screenService = screenService;
  }
  
  public void OnSetUp() {
    // TODO(spike): Create from NodeService.GetBaseScreen(bool cache = true)
    PackedScene baseScene = GD.Load<PackedScene>(
          environmentService.Environment.Paths.Screens.Base);
    Screens.Core.Screen baseScreen = baseScene.Instantiate<BaseScreen>();
    
    screenService.Enter(baseScreen);
  }
  
  public void OnTearDown() {
    screenService.Dismiss();
  }
}
