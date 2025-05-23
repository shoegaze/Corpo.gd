using Corpo.Services.Core;
using Corpo.Services.Environment;

using Godot;

using JsonEnv = Json.Environment;

namespace Corpo.Services.Screen;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuService : Service {
  private readonly EnvironmentService environmentService;

  public MainMenuService(EnvironmentService environmentService) {
    this.environmentService = environmentService;
  }

  public void ToggleSavesSubmenu(Screens.Core.Screen root) {
    JsonEnv.Submenu submenusPaths =
        environmentService.Environment.Path.Screen.MainMenu.Submenu;

    var submenusRoot = root.GetNode(submenusPaths.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO(shoegaze): Fade out animation
      submenusRoot!.Visible = false;

      return;
    }

    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 0;

    Node subMenuSave = submenusRoot!.GetNode(submenusPaths.Saves);

    // TODO(shoegaze): Set up saves UI
  }

  public void ToggleSettingsSubmenu(Screens.Core.Screen root) {
    JsonEnv.Submenu submenusPaths =
        environmentService.Environment.Path.Screen.MainMenu.Submenu;

    var submenusRoot = root.GetNode(submenusPaths.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO(shoegaze): Fade out animation
      submenusRoot!.Visible = false;

      return;
    }

    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 1;

    Node subMenuSettings = submenusRoot!.GetNode(submenusPaths.Settings);

    // TODO(shoegaze): Set up settings UI
  }
}
