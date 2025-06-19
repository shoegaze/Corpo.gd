using Corpo.Bootstrap;
using Corpo.Logging;

using Godot;

using TeamSports;

using Container = Lamar.Container;


namespace Corpo;


public partial class Main : Node {
  [Export] public PackedScene BaseScene { get; private set; }


  public override string ToString() {
    return nameof(Main);
  }

  // Main entrypoint
  public override void _Ready() {
    Container loggerContainer = BuildLoggerContainer();
    var logger = loggerContainer.GetInstance<ILogger>();

    StartGameBootstrap(logger);
  }

  private static Container BuildLoggerContainer() {
    return new Container(new LoggerRegistry());
  }

  private void StartGameBootstrap(ILogger logger) {
    logger.Info("Starting bootstrap...");

    var bootstrapContext =
        new Bootstrapper.BootstrapContext(this, BaseScene, logger);

    Bootstrapper.StartGame(bootstrapContext);
  }
}
