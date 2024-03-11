using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts.Services; 

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
    // TODO(spike): Load packages from disk asynchronously
  }

  public void ShowMainMenu() {
    PackedScene mainMenuScene = GD.Load<PackedScene>(
          environmentService.Environment.Paths.Screens.MainMenu.Path);
    
    Screens.Core.Screen mainMenuScreen = mainMenuScene.Instantiate<Screens.MainMenuScreen>();
    
    screenService.Enter(mainMenuScreen);
  }
}
