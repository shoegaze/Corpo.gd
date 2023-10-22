using Godot;

namespace Corpo.Scripts; 

public abstract class Screen : Node {
  public abstract void OnFocus();
  public abstract void OnCreate();
  public abstract void OnDestroy();
  
  public abstract void Tick(float dt, GameInput? input);
}
