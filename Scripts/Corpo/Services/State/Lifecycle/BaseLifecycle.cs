using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screen.Core;

using Godot;

namespace Corpo.Services.State.Lifecycle;

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
    // TODO(shoegaze): Create from NodeService.GetBaseScreen(bool cache = true)
    var baseScene = GD.Load<PackedScene>(
      environmentService.Environment.Paths.Screens.Base);

    Screens.Core.Screen baseScreen = baseScene.Instantiate<BaseScreen>();

    screenService.Enter(baseScreen);
  }

  public void OnTearDown() {
    screenService.Dismiss();
  }
}
