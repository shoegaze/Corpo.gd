using Corpo.Scripts.Screens.Core;
namespace Corpo.Scripts.Screens; 

// ReSharper disable once ClassNeverInstantiated.Global
public partial class LoadingScreen : Screen {
  public override string ToString() => nameof(LoadingScreen);

  public void OnSetUp() { }
  
  public void OnTearDown() { }
  
  public override void OnFocus() { }
  
  public override void OnCreate() { }
  
  public override void OnDismiss() { }
  
  public override void Tick(float dt, GameInput? input) { }
}
