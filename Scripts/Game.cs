using Corpo.Scripts.Services;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts; 

public partial class Game : Node {
  // Main entrypoint
  public override void _Ready() {
    ServiceProvider.BuildServices();
    
    StateService stateService = ServiceProvider.Get<StateService>();
    stateService.EnterState(GameState.Base);
  }
}