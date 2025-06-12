using Godot;

using Engine.Services;

using Corpo.Generated.Json.Environment;
using Corpo.Screens;
using Corpo.Services.Environment;


namespace Corpo.Services.Screens;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuService(
  EnvironmentService environmentService
) : Service {

  public void ToggleSavesSubmenu(GodotScreen root) {
    Submenu submenusPaths = environmentService.Environment.Path.Screen.MainMenu.Submenu;
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

  public void ToggleSettingsSubmenu(GodotScreen root) {
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
