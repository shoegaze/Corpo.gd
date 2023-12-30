using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts;

public partial class Game : Node {
  private void SetUpServices() {
    GD.Print("Setting up services:");

    EnvironmentService environmentService = ServiceProvider.Get<EnvironmentService>();
    environmentService.LoadEnvironment(
          ProjectSettings.GlobalizePath("res://"),
          EnvironmentService.EnvironmentMode.Development
        );

    NodeService nodeService = ServiceProvider.Get<NodeService>();
    nodeService.LoadNodes(this);

    // TODO(spike): Attach view updater in rootNode process
  }

  // Main
  public override void _Ready() {
    ServiceProvider.BuildServices();

    SetUpServices();

    GD.Print("Starting game ...");
    StateService stateService = ServiceProvider.Get<StateService>();
    stateService.EnterState(GameState.Base);
  }
  
  
}
