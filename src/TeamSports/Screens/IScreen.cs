namespace TeamSports.Screens;


public interface IScreen<in TInput>
where TInput : struct {
  void OnCreate();
  void OnFocus();

  // TODO:
  // void OnFocusIn();
  // void OnFocusOut();

  void OnDismiss();

  void Tick(float dt, TInput input);
}
