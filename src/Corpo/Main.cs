using Corpo.Bootstrap;
using Corpo.Core.Game;

using Godot;

using Container = Lamar.Container;


namespace Corpo;


public partial class Main : Node {
  // TODO: ServicesHelper?
  public static Container ServicesContainer { get; private set; } = null!;


  // Main entrypoint
  public override void _Ready() {
    ServicesContainer = BuildServicesContainer();

    StartGame(ServicesContainer);
  }

  private static Container BuildServicesContainer() {
    return Container.For<BootstrapRegistry>();
  }

  private static void StartGame(Container services) {
    services.GetInstance<IGameDriverService>()
     .Start();
  }
}
