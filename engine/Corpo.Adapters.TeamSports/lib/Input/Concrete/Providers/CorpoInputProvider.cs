using Corpo.Adapters.TeamSports.Input.Concrete.Fragments;
using Corpo.Adapters.TeamSports.Input.Concrete.Fragments.Debug;

using TeamSports.Core.Game.Providers;

using Godot_Input = Godot.Input;


namespace Corpo.Adapters.TeamSports.Input.Concrete.Providers;


public class CorpoInputProvider : IInputProvider<CorpoUserInput> {
  public CorpoUserInput PollInput() {
    return _PollInput();
  }

  private static CorpoUserInput _PollInput() {
    var horizontal =
      new HorizontalInput(
        Left: Godot_Input.IsActionJustPressed("ui_left"),
        Right: Godot_Input.IsActionJustPressed("ui_right"));

    var vertical =
      new VerticalInput(
        Up: Godot_Input.IsActionJustPressed("ui_up"),
        Down: Godot_Input.IsActionJustPressed("ui_down"));

    var selection =
      new SelectionInput(
        Accept: Godot_Input.IsActionJustPressed("ui_accept"),
        Cancel: Godot_Input.IsActionJustPressed("ui_cancel"),
        Cycle: Godot_Input.IsActionJustPressed("ui_focus_next"));

    var debug =
      new DebugInput(
        ToggleEnabled: Godot_Input.IsActionJustPressed("ui_debug_toggle"));

    return new CorpoUserInput(
      Horizontal: horizontal,
      Vertical: vertical,
      Selection: selection,
      Debug: debug);
  }
}
