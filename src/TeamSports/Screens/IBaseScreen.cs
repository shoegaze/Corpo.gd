namespace TeamSports.Screens;


public interface IBaseScreen<TInput> : IScreen<TInput>
where TInput : struct {
  void SetupRoot();
}
