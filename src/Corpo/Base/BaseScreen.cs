using System;

using Corpo.Adaptors.Godot;
using Corpo.Base.Core;

using Lamar;

using TeamSports;


namespace Corpo.Base;


public sealed partial class BaseScreen : GodotBaseScreen {

  private ILogger logger;
  private IBaseService baseService;

  public override string ToString() {
    return nameof(BaseScreen);
  }

  public override void SetupRoot() {
    Services = BuildServiceContainer(logger);

    logger = Services.GetInstance<ILogger>();
    logger.Info($"Created base screen: {this}");

    baseService = Services.GetInstance<IBaseService>();
  }

  public override void OnCreate() {
    baseService.LoadPackages();
  }

  public override void OnFocus() {
    baseService.ShowMainMenu();
  }
}
