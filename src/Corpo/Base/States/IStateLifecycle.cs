namespace Corpo.Base.States;


public interface IStateLifecycle {
  void OnSetUp();
  void OnTearDown();
}
