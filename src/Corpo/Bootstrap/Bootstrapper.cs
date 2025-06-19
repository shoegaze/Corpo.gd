#nullable enable

using Corpo.Base.Nodes;

using Godot;

using TeamSports;

using Container = Lamar.Container;


namespace Corpo.Bootstrap;


public static class Bootstrapper {
  public record BootstrapContext(
    Node mainNode,
    PackedScene baseScene,
    ILogger logger
  );

  public static void StartGame(BootstrapContext context) {
    ILogger logger = context.logger;

    var bootstrapContainer =
        new Container(new BootstrapRegistry());

    logger.Info("Starting game...");

    bootstrapContainer.GetInstance<IBootstrapService>()
       .AttachBaseScreen(context.mainNode, context.baseScene);
  }
}
