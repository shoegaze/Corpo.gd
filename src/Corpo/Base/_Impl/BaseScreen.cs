using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Core.Entities.Screens;


namespace Corpo.Base._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class BaseScreen(
  IBaseService baseService
) : IBaseScreen {

  public string GetName() {
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

  void IScreen<CorpoInput>.OnFocusOut(IScreen<CorpoInput> to) {
    OnFocusOut(to);
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    baseService.ShowMainMenu();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) { }
}
