using Corpo.Base.Core;
using Corpo.Core.Screens;

using TeamSports;


namespace Corpo.Base;


public sealed partial class BaseScreen : CorpoBaseScreen {

  private ILogger logger;
  private IBaseService baseService;

  public override string ToString() {
    return nameof(BaseScreen);
  }

  public override void SetupRoot() {
    Services = BuildServiceContainer(logger);

    logger = Services.GetInstance<ILogger>();
    baseService = Services.GetInstance<IBaseService>();
  }

  public override void OnCreate() {
    logger.Info($"Created base screen: {this}");

    baseService.LoadPackages();
  }

  public override void OnFocus() {
    baseService.ShowMainMenu();
  }
}
