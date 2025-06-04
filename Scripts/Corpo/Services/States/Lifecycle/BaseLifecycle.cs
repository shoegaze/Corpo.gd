using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screens.Core;

using Godot;


namespace Corpo.Services.States.Lifecycle;

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
      environmentService.Environment.Path.Screen.Base);

    global::Corpo.Screens.Core.Screen baseScreen = baseScene.Instantiate<BaseScreen>();

    screenService.Enter(baseScreen);
  }

  public void OnTearDown() {
    screenService.Dismiss();
  }
}
