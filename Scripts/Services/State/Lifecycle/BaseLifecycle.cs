using System;
using Corpo.Scripts.Screens;
using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Environment;
using Fractural.Tasks;
using Godot;

namespace Corpo.Scripts.Services.State.Lifecycle; 

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
    PackedScene baseScene = GD.Load<PackedScene>(
        environmentService.Environment.Paths.Screens.Base
    );
    Screen baseScreen = baseScene.Instantiate<BaseScreen>();
    
    screenService.Enter(baseScreen);

    
    // loadingService.RunAsync(
    //   DebugDoLongProcess, 
    //   () => { 
    //     // DEBUG:
    //     stateService.EnterState(GameState.Battle); 
    //   }).Forget();
  }
  
  public void OnTearDown() {
    screenService.Dismiss();
  }

  private static async GDTask DebugDoLongProcess() {
    GD.Print("Running a long process...");
  
    await GDTask.Delay(TimeSpan.FromSeconds(5.0));
    
    GD.Print("Process complete!");
  }
}
