namespace Corpo.Screens; 

public sealed partial class OverworldScreen : Core.Screen {
  public override string ToString() => nameof(OverworldScreen);
  
  public override void OnFocus() { }
  public override void OnCreate() { }
  public override void OnDismiss() { }
  
  public override void Tick(float dt, GameInput? input) {
    throw new System.NotImplementedException();
  }
}
