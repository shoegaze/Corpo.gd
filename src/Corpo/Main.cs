using Corpo.Bootstrap;

using Godot;

using TeamSports.Services.Game;

using Container = Lamar.Container;


namespace Corpo;


public partial class Main : Node {
  public static Container BaseContainer { get; private set; } = null!;

  // Main entrypoint
  public override void _Ready() {
    BaseContainer = Bootstrapper.GetBootstrapContainer();

    Bootstrapper.StartServices(BaseContainer, this);

    BaseContainer.GetInstance<IGameService>()
     .StartGame();
  }
}
