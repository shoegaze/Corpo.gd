using Corpo.Adapters.TeamSports.Game;
using Corpo.Adapters.TeamSports.Game.Concrete;

using Godot;

using Microsoft.Extensions.DependencyInjection;

using TeamSports.Adapters.Godot.Services;

using Container = Lamar.Container;


namespace Corpo.Bootstrap;


public static class Bootstrapper {
  public static Container GetBootstrapContainer() {
    return new Container(
      services => {
        services.IncludeRegistry<BootstrapRegistry>();

        services.AddSingleton<CorpoStartableTracker>();

        services.For<ICorpoGodotStartable>()
         .OnCreationForAll(
            (context, startable) => {
              context.GetInstance<CorpoStartableTracker>()
               .Startables
               .Add(startable);
            });
      });
  }

  public static void StartServices(Container container, Node rootNode) {
    var tracker = container.GetInstance<CorpoStartableTracker>();
    var startables = tracker.Startables;

    var godotStartContext = new IGodotStartable.GodotStartContext(GameRoot: rootNode);

    foreach (var startable in startables) {
      startable.GodotStart(godotStartContext);
    }
  }
}
