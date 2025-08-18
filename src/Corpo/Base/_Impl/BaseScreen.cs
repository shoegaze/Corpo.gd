using Corpo.Adapters.Input.Concrete;

using TeamSports.Entities.Screens;


namespace Corpo.Base._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class BaseScreen(
  IBaseService baseService
) : IBaseScreen {

  public void SetupRoot() {
    throw new System.NotImplementedException();
  }

  public override string ToString() {
    return GetName();
  }

  public string GetName() {
    return nameof(BaseScreen);
  }

  public void OnCreate() {
    baseService.LoadPackages();
  }

  public void OnDestroy() {
    baseService.DisposePackages();
  }

  public void OnMount() {
    throw new System.NotImplementedException();
  }

  public void OnUnmount() {
    throw new System.NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    baseService.ShowMainMenu();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) { }

}
