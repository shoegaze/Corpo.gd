using Corpo.Adaptors.Godot;


namespace Corpo.Loading;


// ReSharper disable once ClassNeverInstantiated.Global
public partial class LoadingScreen : GodotScreen {
  public override string ToString() {
    return nameof(LoadingScreen);
  }

  public void OnSetUp() { }

  public void OnTearDown() { }

  public override void OnFocus() { }

  public override void OnCreate() { }

  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) { }
}
