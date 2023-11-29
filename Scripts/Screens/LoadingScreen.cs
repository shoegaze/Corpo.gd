namespace Corpo.Scripts.Screens; 

public sealed partial class LoadingScreen : Core.Screen {
  public override string ToString() => nameof(LoadingScreen);
  
  public override void OnFocus() { }
  public override void OnCreate() { }
  public override void OnDismiss() { }
  
  public override void Tick(float dt, GameInput? input) {
    throw new System.NotImplementedException();
  }
}
