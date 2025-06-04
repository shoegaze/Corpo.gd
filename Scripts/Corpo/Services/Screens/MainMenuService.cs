using Corpo.Screens.Core;
using Corpo.Services.Core;
using Corpo.Services.Environment;

using Godot;


namespace Corpo.Services.Screens;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuService : Service {
  private readonly EnvironmentService environmentService;

  public MainMenuService(EnvironmentService environmentService) {
    this.environmentService = environmentService;
  }

  public void ToggleSavesSubmenu(Screen root) {
    var submenusPaths = environmentService.Environment.Path.Screen.MainMenu.Submenu;
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

  public void ToggleSettingsSubmenu(Screen root) {
    var submenusPaths = environmentService.Environment.Path.Screen.MainMenu.Submenu;
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
