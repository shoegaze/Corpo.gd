using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Corpo.Scripts.Services.Resource;
using Godot;

namespace Corpo.Scripts.Services; 

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService : Service {
  private readonly EnvironmentService environmentService;
  private readonly LoadingService loadingService;
  private readonly PackageLoaderService packageLoaderService;
  private readonly ScreenService screenService;
  
  public BaseService(
    EnvironmentService environmentService,
    LoadingService loadingService,
    PackageLoaderService packageLoaderService,
    ScreenService screenService
  ) {
    this.environmentService = environmentService;
    this.loadingService = loadingService;
    this.packageLoaderService = packageLoaderService;
    this.screenService = screenService;
  }

  public async void LoadPackages() {
    await loadingService.RunAsync(async () => {
      await packageLoaderService.LoadPackages();
    });
  }

  public void ShowMainMenu() {
    PackedScene mainMenuScene = GD.Load<PackedScene>(
          environmentService.Environment.Paths.Screens.MainMenu.Root);
    Screens.Core.Screen mainMenuScreen = mainMenuScene.Instantiate<Screens.MainMenuScreen>();
    
    screenService.Enter(mainMenuScreen);
  }
}
