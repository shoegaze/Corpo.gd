using Godot;

using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screens;


namespace Corpo.Services.States.Lifecycle;


public class BaseLifecycle(
  EnvironmentService environmentService,
  ScreenService screenService
)
    : IStateLifecycle {
  private readonly ScreenService screenService = screenService;

  public void OnSetUp() {
    // TODO(shoegaze): Create from NodeService.GetBaseScreen(bool cache = true)
    var baseScene =
        GD.Load<PackedScene>(
              environmentService.Environment.Path.Screen.Base
            );

    GodotScreen baseScreen = baseScene.Instantiate<BaseScreen>();
    screenService.Enter(baseScreen);
  }

  public void OnTearDown() {
    screenService.Dismiss();
  }
}
