using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Screens; 

public sealed partial class BaseScreen : Core.Screen {
  // private BaseService baseService;
  // private NodeService nodeService;
  // private LoadingService loadingService;
  private StateService stateService;

  public override string ToString() => nameof(BaseScreen);

  public override void _Ready() {
    // baseService = ServiceProvider.Get<BaseService>();
    // nodeService = ServiceProvider.Get<NodeService>();
    // loadingService = ServiceProvider.Get<LoadingService>();
    stateService = ServiceProvider.Get<StateService>();
  }

  public override void OnFocus() { }

  public override void OnCreate() {
    // TODO(spike): Show loading screen
    // TODO(spike): Load packages
    
    // loadingService.RunProcess(() => { LoadPackages(); });
    
    // DEBUG: Enter Battle state
    // stateService.EnterState(GameState.Battle);
  }

  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) { }
}
