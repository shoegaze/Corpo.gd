using Engine.Screens;

using Godot;


namespace Corpo.Adaptors.Godot;


public abstract partial class GodotScreen : Node, IScreen<GameInput> {
  public abstract void OnCreate();
  public abstract void OnFocus();
  public abstract void OnDismiss();
  public abstract void Tick(float dt, GameInput? input);
}
