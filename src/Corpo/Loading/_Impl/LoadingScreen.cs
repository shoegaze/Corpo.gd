using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Core.Entities.Screens;


namespace Corpo.Loading._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class LoadingScreen : ILoadingScreen {
  public void Tick(double dt, CorpoUserInput userInput) {
    throw new System.NotImplementedException();
  }

  public override string ToString() {
    return nameof(LoadingScreen);
  }

  public string GetEntityName() {
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

  public void OnFocusIn(IScreen<CorpoUserInput>? from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoUserInput>? to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoUserInput userInput) {
    throw new System.NotImplementedException();
  }

  public void Pause() {
    throw new System.NotImplementedException();
  }

  public void Unpause() {
    throw new System.NotImplementedException();
  }
}
