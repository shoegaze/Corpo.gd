namespace Engine.Screens;


public interface IScreen<TInput>
    where TInput : struct {

  public void OnCreate();
  public void OnFocus();
  public void OnDismiss();

  public void Tick(float dt, TInput? input);
}
