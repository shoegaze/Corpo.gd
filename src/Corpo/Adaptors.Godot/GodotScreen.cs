#nullable enable

using Godot;

using Lamar;

using TeamSports;
using TeamSports.Screens;
using TeamSports.Services;

using Container = Lamar.Container;


namespace Corpo.Adaptors.Godot;


public abstract partial class GodotScreen : Node, IScreen<GameInput> {
  public abstract Container Services { get; }


  protected static Container BuildContainer<TRegistry>(
    ILogger? logger = null
  )
  where TRegistry : ServiceRegistry, new() {
    string nameOfRegistry = typeof(TRegistry).FullName ?? nameof(TRegistry);

    logger?.Info($"Building {nameOfRegistry} services...");

    return new Container(services => {
      logger?.Debug($"Including {nameOfRegistry} services registry");
      services.IncludeRegistry<TRegistry>();

      services.For<IStartable>()
         .OnCreationForAll((_, startable) => {
            logger?.Debug($"Starting service: {startable}");
            startable.Start();
          });
    });
  }

  public abstract void OnCreate();
  public abstract void OnFocus();
  public abstract void OnDismiss();
  public abstract void Tick(float dt, GameInput? input);
}
