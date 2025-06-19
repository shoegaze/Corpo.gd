using System;

using Corpo.Adaptors.Godot;
using Corpo.Base.Core;

using Lamar;

using TeamSports;


namespace Corpo.Base;


// TODO: Define GodotRootScreen : GodotScreen, IRootScreen
public sealed partial class BaseScreen : GodotBaseScreen {

  private Container baseContainer;

  private ILogger logger;
  private IBaseService baseService;

  public override string ToString() {
    return nameof(BaseScreen);
  }


  public override Container Services => baseContainer;


  public override void SetupRoot() {
    baseContainer = BuildContainer<BaseRegistry>(logger);

    logger = baseContainer.GetInstance<ILogger>();
    logger.Info($"Created base screen: {this}");

    baseService = baseContainer.GetInstance<IBaseService>();
  }

  public override void OnCreate() {
    baseService.LoadPackages();
  }

  public override void OnFocus() {
    baseService.ShowMainMenu();
  }

  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) {
    throw new NotImplementedException();
  }
}
