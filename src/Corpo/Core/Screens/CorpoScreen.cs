using Corpo.Adaptors.Godot;
using Corpo.Adaptors.Godot.Screens;

using Godot;

using Lamar;


namespace Corpo.Core.Screens;


public partial class CorpoScreen<TRegistry>
    : GodotScreen<TRegistry, CorpoInput>, ICorpoScreen
where TRegistry : ServiceRegistry, new() {
  protected CorpoInput Input; // TODO: Input = CorpoInput.Empty;

  public override void _Input(InputEvent @event) {
    Input = InputHelper.PollInput();
  }

  // TODO: After _Process, flush input
  // public override void _Process(double delta) { }
}
