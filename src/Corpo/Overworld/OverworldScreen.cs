using System;

using Corpo.Adaptors.Godot;


namespace Corpo.Overworld;


public sealed partial class OverworldScreen : GodotScreen {
  public override string ToString() {
    return nameof(OverworldScreen);
  }

  public override void OnFocus() { }
  public override void OnCreate() { }
  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) {
    throw new NotImplementedException();
  }
}
