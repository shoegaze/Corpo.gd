using Godot;

namespace Corpo.Scripts.Screens.Core; 

public abstract partial class Screen : Node {
  public abstract void OnCreate();
  public abstract void OnFocus();
  public abstract void OnDismiss();
  
  public abstract void Tick(float dt, GameInput? input);
}
