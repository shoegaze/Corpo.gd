using Corpo.Services;
using Corpo.Services.Core;

namespace Corpo.Screens; 

public sealed partial class BaseScreen : Core.Screen {
  private BaseService baseService;

  public override string ToString() => nameof(BaseScreen);

  public override void _Ready() {
    baseService = ServiceProvider.Get<BaseService>();
  }

  public override void OnCreate() {
    baseService.LoadPackages();
  }

  public override void OnFocus() {
    baseService.ShowMainMenu();
  }
  
  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) { }
}
