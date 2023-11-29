using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts;

public partial class Game : Node {
  private void SetUpServices() {
    EnvironmentService environmentService = ServiceProvider.Get<EnvironmentService>();
    environmentService.LoadEnvironment(ProjectSettings.GlobalizePath("res://"),
                                       EnvironmentService.EnvironmentMode.Development);

    NodeService nodeService = ServiceProvider.Get<NodeService>();
    nodeService.LoadNodes(this);
  }
  
  // Main
  public override void _Ready() {
    ServiceProvider.BuildServices();

    SetUpServices();

    StateService stateService = ServiceProvider.Get<StateService>();
    stateService.EnterState(GameState.Base);
  }
}
