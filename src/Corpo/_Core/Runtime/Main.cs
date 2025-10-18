using Corpo._Core.Screens;
using Corpo.Base;

using Container = Lamar.Container;
using CorpoBootstrap = Corpo._App.CorpoBootstrap;


namespace Corpo._Core.Runtime;


public partial class Main : CorpoBootstrap {
  // TODO: ServicesHelper?
  public static Container ServicesContainer { get; } =
    Bootstrap.GetBootstrappedContainer();


  // Main entrypoint
  public override void _Ready() {
    base._Ready();

    StartGame(ServicesContainer);
  }

  private static void StartGame(Container services) {
    services.GetInstance<IScreensService>()
     .EnterScreen<IBaseScreen>();
  }
}
