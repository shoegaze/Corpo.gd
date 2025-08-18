using System;

using Corpo.Adapters.Input.Concrete;
using Corpo.Core.Screens;
using Corpo.MainMenu.Debug;

using TeamSports.Entities.Screens;


namespace Corpo.MainMenu._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public class MainMenuScreen(
  IScreenService screenService,
  IMainMenuService mainMenuService
) : IMainMenuScreen {

  public override string ToString() {
    return GetName();
  }

  public string GetName() {
    return nameof(MainMenuScreen);
  }

  public void OnCreate() {
    mainMenuService.SetupViews();
    mainMenuService.BindScreen(this);
  }

  public void OnDestroy() {
    throw new NotImplementedException();
  }

  public void OnMount() {
    mainMenuService.SetupViews();

    throw new NotImplementedException();
  }

  public void OnUnmount() {
    mainMenuService.CleanUpViews();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    // DEBUG:
    screenService.EnterScreen<IMainMenuDebugScreen>(focusImmediately: false);
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) {
    throw new NotImplementedException();
  }
}
