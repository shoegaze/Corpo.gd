using Engine.Services;

using Corpo.Services.Environment;
using Corpo.Services.Screens;


namespace Corpo.Services;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoadingService(
  EnvironmentService environmentService,
  ScreenService screenService
)
    : Service {
  private readonly EnvironmentService environmentService = environmentService;
  private readonly ScreenService screenService = screenService;


  public bool IsLoading { get; private set; } = false;


  /*
  // TODO(shoegaze): Func<Action<double> setLoadingProgress, GDTask action> action
  public async GDTask RunAsync(Func<GDTask> action, Action onComplete) {
    if (IsLoading) {
      GD.PrintErr("Cannot run task: LoadingService is busy");

      return;
    }

    StartLoading();
    Do(action, onComplete).Forget();

    await GDTask.Yield();
  }

  public async GDTask RunAsync(Func<GDTask> action) {
    await RunAsync(action, () => {});
  }

  private void ShowLoadingScreen() {
    var loadingScene = GD.Load<PackedScene>(
      environmentService.Environment.Paths.Screens.Loading);

    Screens.Core.Screen loadingScreen = loadingScene.Instantiate<LoadingScreen>();

    screenService.Enter(loadingScreen);
  }

  private void StartLoading() {
    IsLoading = true;
    ShowLoadingScreen();
  }

  private void EndLoading() {
    IsLoading = false;
    screenService.Dismiss();
  }

#pragma warning disable CS1998
  private async GDTask Do(Func<GDTask> action, Action onComplete) {
#pragma warning restore CS1998
    action().GetAwaiter()
            .OnCompleted(() => {
               EndLoading();
               onComplete();
             });

    GDTask.Yield();
  }
  */
}
