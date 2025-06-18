using System;

using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Base.Screens;
using Corpo.MainMenu;

using Godot;


namespace Corpo.Base.Core.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class BaseService(
  IEnvironmentService environmentService,
  IScreenService screenService
) : IBaseService {
  public void LoadPackages() {
    throw new NotImplementedException();
  }

  public void ShowMainMenu() {
    string mainMenuScenePath =
        environmentService.Environment.Path.Screen.MainMenu.Path;

    var mainMenuScene = GD.Load<PackedScene>(mainMenuScenePath);

    GodotScreen mainMenuScreen = mainMenuScene.Instantiate<MainMenuScreen>();

    screenService.Enter(mainMenuScreen);
  }
}
