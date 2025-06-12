namespace Corpo.Services.States;


public interface IStateLifecycle {
  void OnSetUp();
  void OnTearDown();
}
