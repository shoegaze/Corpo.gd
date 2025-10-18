using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Core.Entities.Screens;


namespace Corpo.Base._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class BaseScreen(
  IBaseService baseService
) : IBaseScreen {

  public string GetEntityName() {
    return nameof(BaseScreen);
  }

  public void OnCreate() {
    baseService.LoadPackages();
  }

  public void OnDestroy() {
    // baseService.DisposePackages();
    throw new System.NotImplementedException();
  }

  public void OnMount() {
    throw new System.NotImplementedException();
  }

  public void OnUnmount() {
    throw new System.NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoUserInput>? from) {
    baseService.ShowMainMenu();
  }

  public void OnFocusOut(IScreen<CorpoUserInput>? to) {
    throw new System.NotImplementedException();
  }

  public void Tick(double dt, CorpoUserInput userInput) {
    throw new System.NotImplementedException();
  }

  public void Pause() {
    throw new System.NotImplementedException();
  }

  public void Unpause() {
    throw new System.NotImplementedException();
  }
}
