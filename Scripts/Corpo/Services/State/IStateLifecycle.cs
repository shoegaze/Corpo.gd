namespace Corpo.Services.State; 

public interface IStateLifecycle {
  void OnSetUp();
  void OnTearDown();
}
