namespace TeamSports.Screens;


public abstract class ScreenComponent<TInput>
where TInput : struct {

  // public abstract void OnCreate();
  public abstract void OnFocus();
  public abstract void OnUnfocus();
  public abstract void OnDestroy();

  // public abstract void Update(float dt);
  public abstract void Tick(float dt, TInput input);
}
