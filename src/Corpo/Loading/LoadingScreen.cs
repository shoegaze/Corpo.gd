namespace Corpo.Loading;


public interface ILoadingScreen : IScreen;

// ReSharper disable once ClassNeverInstantiated.Global
// ReSharper disable once UnusedType.Global
public sealed class LoadingScreen : ILoadingScreen {
  public void Tick(double dt, UserInput userInput) {
    throw new System.NotImplementedException();
  }

  public override string ToString() {
    return nameof(LoadingScreen);
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

  public void OnFocusIn(IScreen<UserInput>? from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<UserInput>? to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, UserInput userInput) {
    throw new System.NotImplementedException();
  }

  public void Pause() {
    throw new System.NotImplementedException();
  }

  public void Unpause() {
    throw new System.NotImplementedException();
  }
}
