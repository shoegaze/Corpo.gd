using Corpo.Adaptors.Godot.Debug;

using Lamar;


namespace Corpo.Core.Screens;


public abstract partial class CorpoDebugScreen<TRegistry>
    : GodotDebugScreen<TRegistry, CorpoInput>
where TRegistry : ServiceRegistry, new() {
  public override void Tick(float dt, CorpoInput input) {
    base.Tick(dt, input);

    Draw(dt, input);
  }
}
