using Corpo.Adapters.TeamSports.Input.Concrete.Fragments;
using Corpo.Adapters.TeamSports.Input.Concrete.Fragments.Debug;

using Godot_Input = Godot.Input;


namespace Corpo.Adapters.TeamSports.Input.Concrete.Helpers;


public static class InputHelper {
  public static CorpoInput PollInput() {
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

    return new CorpoInput(
      Horizontal: horizontal,
      Vertical: vertical,
      Selection: selection,
      Debug: debug);
  }
}
