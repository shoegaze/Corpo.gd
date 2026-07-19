using System;

using Corpo._Core.Screens;
using Corpo.Adapters.TeamSports.Input.Concrete;
using Corpo.Adapters.TeamSports.Screens;
using Corpo.MainMenu.Debug;

using TeamSports.Core.Entities.Screens;


namespace Corpo.MainMenu;


public interface IMainMenuScreen : IScreen;

// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class MainMenuScreen(
  IScreensService screensService,
  IMainMenuService mainMenuService
) : IMainMenuScreen {
  public void Tick(double dt, UserInput userInput) {
    throw new NotImplementedException();
  }

  public override string ToString() {
    return GetEntityName();
  }

  public string GetEntityName() {
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

  public void OnFocusIn(IScreen<UserInput>? from) {
    throw new NotImplementedException();
  }

  public void OnFocusOut(IScreen<UserInput>? to) {
    throw new NotImplementedException();
  }

  public void OnFocusIn(ICorpoScreen from) {
    // DEBUG:
    screensService.EnterScreen<IMainMenuDebugScreen>(

      /* TODO: focusImmediately: false*/
    );
  }

  public void OnFocusOut(ICorpoScreen to) {
    throw new NotImplementedException();
  }

  public void Tick(float dt, UserInput userInput) {
    throw new NotImplementedException();
  }

  public void Pause() {
    throw new NotImplementedException();
  }

  public void Unpause() {
    throw new NotImplementedException();
  }
}
