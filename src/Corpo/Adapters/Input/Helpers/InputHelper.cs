using Corpo.Adapters.Input.Concrete;

using Godot_Input = Godot.Input;


namespace Corpo.Adapters.Input.Helpers;


public static class InputHelper {
  public static CorpoInput PollInput() {
    var horizontal =
      new Horizontal(
        Left: Godot_Input.IsActionJustPressed("ui_left"),
        Right: Godot_Input.IsActionJustPressed("ui_right"));

    var vertical =
      new Vertical(
        Up: Godot_Input.IsActionJustPressed("ui_up"),
        Down: Godot_Input.IsActionJustPressed("ui_down"));

    var decide =
      new Decide(
        Accept: Godot_Input.IsActionJustPressed("ui_accept"),
        Cancel: Godot_Input.IsActionJustPressed("ui_cancel"),
        Cycle: Godot_Input.IsActionJustPressed("ui_focus_next"));

    var debug =
      new DebugInput(
        Toggle: Godot_Input.IsActionJustPressed("ui_debug_toggle"));

    return new CorpoInput(
      Horizontal: horizontal,
      Vertical: vertical,
      Decide: decide,
      Debug: debug);
  }
}
