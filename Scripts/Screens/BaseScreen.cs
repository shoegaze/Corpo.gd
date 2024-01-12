using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts.Screens; 

public sealed partial class BaseScreen : Core.Screen {
  // private BaseService baseService;
  // private NodeService nodeService;
  // private LoadingService loadingService;
  // private StateService stateService;
  private EnvironmentService environmentService;
  private ScreenService screenService;

  public override string ToString() => nameof(BaseScreen);

  public override void _Ready() {
    // baseService = ServiceProvider.Get<BaseService>();
    // nodeService = ServiceProvider.Get<NodeService>();
    // loadingService = ServiceProvider.Get<LoadingService>();
    // stateService = ServiceProvider.Get<StateService>();
    
    environmentService = ServiceProvider.Get<EnvironmentService>();
    screenService = ServiceProvider.Get<ScreenService>();
  }

  public override void OnCreate() {
    // TODO(spike): Show loading screen
    // TODO(spike): Load packages
    
    // loadingService.RunAsync(() => { LoadPackages(); });
  }

  public override void OnFocus() {
    GD.Print("BaseScreen onFocus");
    
    PackedScene mainMenuScene = GD.Load<PackedScene>(
          environmentService.Environment.Paths.Screens.MainMenu
        );
    Screen mainMenuScreen = mainMenuScene.Instantiate<MainMenuScreen>();
    
    screenService.Enter(mainMenuScreen);
  }
  
  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) { }
}
