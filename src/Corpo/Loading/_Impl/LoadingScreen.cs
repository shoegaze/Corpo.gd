using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Entities.Screens;


namespace Corpo.Loading._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class LoadingScreen : ILoadingScreen {
  public override string ToString() {
    return nameof(LoadingScreen);
  }

  public string GetName() {
    throw new System.NotImplementedException();
  }

  public void OnCreate() {
    throw new System.NotImplementedException();
  }

  public void OnDestroy() {
    throw new System.NotImplementedException();
  }

  public void OnMount() {
    throw new System.NotImplementedException();
  }

  public void OnUnmount() {
    throw new System.NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) {
    throw new System.NotImplementedException();
  }
}
