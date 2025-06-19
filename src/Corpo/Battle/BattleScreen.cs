using System;

using Corpo.Adaptors.Godot;

using Lamar;

using TeamSports;


namespace Corpo.Battle;


public sealed partial class BattleScreen : GodotScreen {
  private Container battleContainer;

  private ILogger logger;

  public override string ToString() {
    return nameof(BattleScreen);
  }


  public override Container Services => battleContainer;


  public override void OnCreate() {
    battleContainer = BuildContainer<BattleRegistry>(logger);
    logger = battleContainer.GetInstance<ILogger>();
  }

  public override void OnFocus() { }
  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) {
    throw new NotImplementedException();
  }
}
