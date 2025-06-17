using System;

using Corpo.Adaptors.Godot;


namespace Corpo.Base;


public sealed partial class BaseScreen : GodotScreen {
  private IBaseService baseService;

  public override string ToString() {
    return nameof(BaseScreen);
  }

  public override void _Ready() {
    baseService = Main.BaseContainer.GetInstance<IBaseService>();
  }

  public override void OnCreate() {
    // TODO: Move to loader
    baseService.LoadPackages();
  }

  public override void OnFocus() {
    baseService.ShowMainMenu();
  }

  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) {
    // TODO;
    throw new NotImplementedException();
  }
}
