using Corpo.Scripts.Screens;
using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services;
using Godot;

namespace Corpo.Scripts.State; 

public class BaseLifecycle : IStateLifecycle {
  private readonly StateService stateService;
  private readonly EnvironmentService environmentService;
  private readonly ScreenService screenService;
  private readonly LoadingService loadingService;
  
  public BaseLifecycle(
    StateService stateService,
    EnvironmentService environmentService, 
    ScreenService screenService,
    LoadingService loadingService
  ) {
    this.stateService = stateService;
    this.environmentService = environmentService;
    this.screenService = screenService;
    this.loadingService = loadingService;
  }
  
  public void OnSetUp() {
    // TODO(spike): Create from NodeService.GetBaseScreen(bool cache = true)
    string baseScenePath = environmentService.Environment.Paths.Screens.Base;
    PackedScene baseScene = GD.Load<PackedScene>(baseScenePath);
    Screen baseScreen = baseScene.Instantiate<BaseScreen>();
    
    screenService.Enter(baseScreen);
  }
  
  public void OnTearDown() {
    screenService.Dismiss();
  }
}
