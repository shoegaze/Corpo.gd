using System;
using Corpo.Scripts.Screens;
using Corpo.Scripts.Screens.Core;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Fractural.Tasks;
using Godot;

namespace Corpo.Scripts.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class LoadingService : Service {
  private readonly EnvironmentService environmentService;
  private readonly ScreenService screenService;
  
  public bool IsLoading { get; private set; }

  // TODO(spike): Inject services
  public LoadingService(
    EnvironmentService environmentService, 
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.screenService = screenService;
    
    IsLoading = false;
  }
  
  // TODO(spike): Func<Action<double> setLoadingProgress, GDTask action> action 
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
    await RunAsync(action, () => { });
  }

  private void ShowLoadingScreen() {
    PackedScene loadingScene = GD.Load<PackedScene>(
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
}
