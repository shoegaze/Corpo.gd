using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;

namespace Corpo.Scripts.Screens; 

public sealed partial class BaseScreen : Core.Screen {
  private BaseService baseService;
  private NodeService nodeService;
  private LoadingService loadingService;

  public override void _Ready() {
    baseService = ServiceProvider.Get<BaseService>();
    nodeService = ServiceProvider.Get<NodeService>();
    loadingService = ServiceProvider.Get<LoadingService>();
  }

  public override void OnFocus() { }

  public override void OnCreate() {
    // TODO(spike): Show loading screen
    // TODO(spike): Load packages
    
    // loadingService.RunProcess(LoadPackages);
  }

  public override void OnDismiss() { }
  
  public override void Tick(float dt, GameInput? input) { }
}
