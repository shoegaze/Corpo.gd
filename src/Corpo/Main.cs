using Corpo.Base;
using Corpo.Base.Nodes;
using Corpo.Base.States;
using Corpo.Logging;

using Engine;
using Engine.Services;

using Godot;

using Container = Lamar.Container;


namespace Corpo;


public partial class Main : Node {
  public static Container BaseContainer;

  // Main entrypoint
  public override void _Ready() {
    ILogger logger = BuildLogger();
    BaseContainer = BuildBaseServices(logger);

    StartGame(logger);
  }

  private ILogger BuildLogger() {
    return new Container(new LoggerRegistry())
       .GetInstance<ILogger>();
  }

  private Container BuildBaseServices(ILogger logger) {
    logger.Info("Building base services...");

    return new Container(services => {
      logger.Debug("Including base services registry");
      services.IncludeRegistry<BaseRegistry>();

      services.For<IStartable>()
         .OnCreationForAll((_, startable) => {
            logger.Debug($"Starting service: {startable}");
            startable.Start();
          });
    });
  }

  private void StartGame(ILogger logger) {
    logger.Info("Starting game...");

    BaseContainer.GetInstance<INodeService>()
       .LoadRoot(this);

    BaseContainer.GetInstance<IStateService>()
       .EnterState(StateService.GameState.Base);
  }
}
