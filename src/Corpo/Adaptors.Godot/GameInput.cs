using Godot;


namespace Corpo.Adaptors.Godot;


// TODO: Replace with `InputService`
public struct GameInput(
  bool up,
  bool down,
  bool right,
  bool left,
  bool accept,
  bool cancel,
  bool cycle
) {
  public readonly bool Up = up;
  public readonly bool Down = down;
  public readonly bool Right = right;
  public readonly bool Left = left;
  public readonly bool Accept = accept;
  public readonly bool Cancel = cancel;
  public readonly bool Cycle = cycle;

  public static GameInput Poll() {
    bool up = Input.IsActionJustPressed("ui_up");
    bool down = Input.IsActionJustPressed("ui_down");
    bool right = Input.IsActionJustPressed("ui_right");
    bool left = Input.IsActionJustPressed("ui_left");
    bool accept = Input.IsActionJustPressed("ui_accept");
    bool cancel = Input.IsActionJustPressed("ui_cancel");
    bool cycle = Input.IsActionJustPressed("ui_focus_next");

    return new GameInput(
      up,
      down,
      right,
      left,
      accept,
      cancel,
      cycle);
  }
}
