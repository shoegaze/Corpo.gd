using Corpo.Adaptors.Godot;


namespace Corpo.Battle;


public sealed partial class BattleScreen : GodotScreen<BattleRegistry> {
  public override string ToString() {
    return nameof(BattleScreen);
  }
}
