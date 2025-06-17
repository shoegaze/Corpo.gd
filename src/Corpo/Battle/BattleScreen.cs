using System;

using Corpo.Adaptors.Godot;


namespace Corpo.Battle;


public sealed partial class BattleScreen : GodotScreen {
  public override string ToString() {
    return nameof(BattleScreen);
  }

  public override void OnFocus() { }
  public override void OnCreate() { }
  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) {
    throw new NotImplementedException();
  }
}
