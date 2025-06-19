using Godot;


namespace Corpo.Adaptors.Godot;


public static class InputExtensions {
  public static CorpoInput PollInput() {
    var horizontal =
        new Horizontal(
          Left: Input.IsActionJustPressed("ui_left"),
          Right: Input.IsActionJustPressed("ui_right"));

    var vertical =
        new Vertical(
          Up: Input.IsActionJustPressed("ui_up"),
          Down: Input.IsActionJustPressed("ui_down"));

    var decide =
        new Decide(
          Accept: Input.IsActionJustPressed("ui_accept"),
          Cancel: Input.IsActionJustPressed("ui_cancel"),
          Cycle: Input.IsActionJustPressed("ui_focus_next"));

    var debug =
        new DebugInput(
          Toggle: Input.IsActionJustPressed("ui_debug_toggle"));

    return new CorpoInput(
      Horizontal: horizontal,
      Vertical: vertical,
      Decide: decide,
      Debug: debug);
  }
}
