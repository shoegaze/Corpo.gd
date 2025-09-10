using System;

using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.Core.Screens;
using Corpo.MainMenu.Debug;

using TeamSports.Core.Entities.Screens;


namespace Corpo.MainMenu._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class MainMenuScreen(
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
    mainMenuService.BindScreen(this);
  }

  public void OnDestroy() {
    throw new NotImplementedException();
  }

  public void OnMount() {
    throw new NotImplementedException();
  }

  public void OnUnmount() {
    throw new NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    throw new NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new NotImplementedException();
  }

  public void OnFocusIn(ICorpoScreen from) {
    // DEBUG:
    screenService.EnterScreen<IMainMenuDebugScreen>(focusImmediately: false);
  }

  public void OnFocusOut(ICorpoScreen to) {
    throw new NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) {
    throw new NotImplementedException();
  }
}
