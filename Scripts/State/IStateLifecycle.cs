namespace Corpo.Scripts.State; 

public interface IStateLifecycle {
  void OnSetUp();
  void OnTearDown();
}
