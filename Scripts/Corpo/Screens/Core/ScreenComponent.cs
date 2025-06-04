using Godot;


namespace Corpo.Screens.Core; 

public abstract partial class ScreenComponent : Node {
  public abstract void OnFocus();
  public abstract void OnUnfocus();
  public abstract void OnDestroy();

  public abstract void Update(float dt);
  public abstract void Tick(float dt, GameInput? input);
}
