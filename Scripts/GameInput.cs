using Godot;

namespace Corpo.Scripts;

public struct GameInput {
  public readonly bool Up;
  public readonly bool Down;
  public readonly bool Right;
  public readonly bool Left;
  public readonly bool Accept;
  public readonly bool Cancel;
  public readonly bool Cycle;

  public GameInput(
    bool up,
    bool down,
    bool right,
    bool left,
    bool accept,
    bool cancel,
    bool cycle
  ) {
    Up = up;
    Down = down;
    Right = right;
    Left = left;
    Accept = accept;
    Cancel = cancel;
    Cycle = cycle;
  }

  public static GameInput FromGlobal() {
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
      cycle
    );
  }
}