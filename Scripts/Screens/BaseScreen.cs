using Corpo.Scripts.Services;

namespace Corpo.Scripts.Screens; 

public sealed partial class BaseScreen : Screen {
  // private BaseService baseService;
  
  public override void OnFocus() { }

  public override void OnCreate() {
    // TODO(spike): Show loading screen
    // TODO(spike): Load packages
  }

  public override void OnDestroy() {
    // TODO(spike): Dismiss loading screen
  }
  
  public override void Tick(float dt, GameInput? input) { }
}
