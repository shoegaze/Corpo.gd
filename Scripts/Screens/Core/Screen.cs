using Godot;

namespace Corpo.Scripts.Screens.Core; 

public abstract partial class Screen : Node {
  // protected abstract string ScenePath { get; }
  // protected abstract void Instantiate();
  
  public abstract void OnFocus();
  public abstract void OnCreate();
  public abstract void OnDismiss();
  
  public abstract void Tick(float dt, GameInput? input);
}
