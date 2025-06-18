using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.Base.States;

using Godot;


namespace Corpo.Base.Core.Models;


public class BaseLifecycle(
  IEnvironmentService environmentService,
  IScreenService screenService
) : IStateLifecycle {
  public void OnSetUp() {
    // TODO: Create from INodeService.GetBaseScreen(bool cache = true)
    string baseScenePath = environmentService.Environment.Path.Screen.Base;
    var baseScene = GD.Load<PackedScene>(baseScenePath);

    GodotScreen baseScreen = baseScene.Instantiate<BaseScreen>();
    screenService.Enter(baseScreen);
  }

  public void OnTearDown() {
    screenService.Dismiss();
  }
}
