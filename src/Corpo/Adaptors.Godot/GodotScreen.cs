#nullable enable

using Godot;

using Lamar;

using TeamSports;
using TeamSports.Services;

using Container = Lamar.Container;


namespace Corpo.Adaptors.Godot;


public abstract partial class GodotScreen<TRegistry> : Node, IGodotScreen
where TRegistry : ServiceRegistry, new() {
  public Container Services { get; protected set; } = null!;


  public Node ToNode() {
    return this;
  }

  protected Container BuildServiceContainer(
    ILogger? logger = null
  ) {
    string nameOfRegistry = typeof(TRegistry).FullName ?? nameof(TRegistry);

    logger?.Info($"Building {nameOfRegistry} services...");

    return new Container(s => {
      logger?.Debug($"Including {nameOfRegistry} services registry");
      s.IncludeRegistry<TRegistry>();

      s.For<IStartable>()
         .OnCreationForAll((_, startable) => {
            logger?.Debug($"Starting service: {startable}");
            startable.Start();
          });
    });
  }

  public virtual void OnCreate() {
    Services = BuildServiceContainer();
  }

  public virtual void OnDismiss() {
    Services.Dispose();
  }

  public virtual void OnFocus() { }

  public virtual void Tick(float dt, CorpoInput input) { }
}
