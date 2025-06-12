using Godot;

using Engine.Screens;


namespace Corpo.Screens;


public abstract partial class GodotScreen : Node, IScreen<GameInput> {
  public abstract void OnCreate();
  public abstract void OnFocus();
  public abstract void OnDismiss();
  public abstract void Tick(float dt, GameInput? input);
}
