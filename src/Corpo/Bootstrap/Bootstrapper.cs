using System.Collections.Generic;

using Corpo.Adapters.Services;
using Corpo.Adaptors.Concrete;

using Godot;

using Microsoft.Extensions.DependencyInjection;

using Container = Lamar.Container;


namespace Corpo.Bootstrap;


public static class Bootstrapper {
  public static Container GetBootstrapContainer() {
    return new Container(
      services => {
        services.IncludeRegistry<BootstrapRegistry>();

        services.AddSingleton<CorpoStartableTracker>();

        services.For<ICorpoStartable>()
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
    List<ICorpoStartable> startables = tracker.Startables;

    foreach (ICorpoStartable startable in startables) {
      startable.GodotStart(rootNode);
    }
  }
}
