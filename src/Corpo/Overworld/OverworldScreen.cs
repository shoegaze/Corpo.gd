using System;

using Corpo.Adaptors.Godot;

using Lamar;

using TeamSports;


namespace Corpo.Overworld;


public sealed partial class OverworldScreen : GodotScreen {
  private Container overworldContainer;

  private ILogger logger;

  public override string ToString() {
    return nameof(OverworldScreen);
  }


  public override Container Services => overworldContainer;


  public override void OnCreate() {
    overworldContainer = BuildContainer<OverworldRegistry>(logger);
    logger = overworldContainer.GetInstance<ILogger>();
  }

  public override void OnDismiss() { }
  public override void OnFocus() { }

  public override void Tick(float dt, GameInput? input) {
    throw new NotImplementedException();
  }
}
