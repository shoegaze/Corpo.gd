using Corpo.Screens;
using Corpo.Services.Core;
using Corpo.Services.Environment;
using Corpo.Services.Screen.Core;

using Godot;

namespace Corpo.Services;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService : Service {
  private readonly EnvironmentService environmentService;
  private readonly LoadingService loadingService;
  private readonly ScreenService screenService;

  public BaseService(
    EnvironmentService environmentService,
    LoadingService loadingService,
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.loadingService = loadingService;
    this.screenService = screenService;
  }

  public async void LoadPackages() {
    // TODO(shoegaze): Load packages from disk asynchronously
  }

  public void ShowMainMenu() {
    var mainMenuScene = GD.Load<PackedScene>(
      environmentService.Environment.Path.Screen.MainMenu.Path);

    Screens.Core.Screen mainMenuScreen = mainMenuScene.Instantiate<MainMenuScreen>();

    screenService.Enter(mainMenuScreen);
  }
}
