namespace Corpo.Screens; 

public sealed partial class BattleScreen : Screens.Core.Screen {
  public override string ToString() => nameof(BattleScreen);

  public override void OnFocus() { }
  public override void OnCreate() { }
  public override void OnDismiss() { }
  
  public override void Tick(float dt, GameInput? input) {
    throw new System.NotImplementedException();
  }
}
