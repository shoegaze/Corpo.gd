namespace Corpo.Scripts.Services.State; 

public interface IStateLifecycle {
  void OnSetUp();
  void OnTearDown();
}
