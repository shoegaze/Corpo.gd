using System;

using Godot;

using Engine.Services;

using Corpo.Screens;
using Corpo.Services.Environment;
using Corpo.Services.Screens;


namespace Corpo.Services;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService(
  EnvironmentService environmentService,
  LoadingService loadingService,
  ScreenService screenService
)
    : Service {
  private readonly LoadingService loadingService = loadingService;
  private readonly ScreenService screenService = screenService;

  public /*async*/ void LoadPackages() {
    // TODO(shoegaze): Load packages from disk asynchronously
    throw new NotImplementedException();
  }

  public void ShowMainMenu() {
    var mainMenuScene =
        GD.Load<PackedScene>(
              environmentService.Environment.Path.Screen.MainMenu.Path
            );

    GodotScreen mainMenuScreen = mainMenuScene.Instantiate<MainMenuScreen>();

    screenService.Enter(mainMenuScreen);
  }
}
