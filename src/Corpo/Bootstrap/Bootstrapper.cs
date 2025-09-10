using Corpo.Adapters.TeamSports.Game;
using Corpo.Adapters.TeamSports.Game.Concrete;

using Godot;

using Microsoft.Extensions.DependencyInjection;

using TeamSports.Adapters.Godot.Services;

using Container = Lamar.Container;
using IGodotStartable = Corpo.Adapters.TeamSports.Game.IGodotStartable;


namespace Corpo.Bootstrap;


public static class Bootstrapper {
  public static Container GetBootstrapContainer() {
    return new Container(
      services => {
        services.IncludeRegistry<BootstrapRegistry>();

        services.AddSingleton<StartablesTracker>();

        services.For<IGodotStartable>()
         .OnCreationForAll(
            (context, startable) => {
              context.GetInstance<StartablesTracker>()
               .Startables
               .Add(startable);
            });
      });
  }

  public static void StartServices(Container container, Node rootNode) {
    var tracker = container.GetInstance<StartablesTracker>();
    var startables = tracker.Startables;

    var godotStartContext =
      new TeamSports.Adapters.Godot.Services.IGodotStartable.GodotStartContext(
        GameRoot: rootNode);

    foreach (var startable in startables) {
      startable.GodotStart(godotStartContext);
    }
  }
}
