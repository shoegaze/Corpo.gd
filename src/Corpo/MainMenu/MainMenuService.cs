using Corpo.Adaptors.Godot;
using Corpo.Base.Environments;
using Corpo.Generated.Json.Environment;

using Godot;


namespace Corpo.MainMenu;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuService(
  IEnvironmentService environmentService
) : IMainMenuService {

  public void ToggleSavesSubmenu(GodotScreen root) {
    Submenu submenuPath =
        environmentService.Environment.Path.Screen.MainMenu.Submenu;

    var submenusRoot = root.GetNode(submenuPath.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO: Fade out animation
      submenusRoot!.Visible = false;

      return;
    }

    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 0;

    // TODO: Set up saves UI
    // Node subMenuSave = submenusRoot!.GetNode(submenuPath.Saves);
  }

  public void ToggleSettingsSubmenu(GodotScreen root) {
    Submenu submenusPaths =
        environmentService.Environment.Path.Screen.MainMenu.Submenu;

    var submenusRoot = root.GetNode(submenusPaths.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO: Fade out animation
      submenusRoot!.Visible = false;

      return;
    }

    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 1;

    // TODO: Set up settings UI
    // Node subMenuSettings = submenusRoot!.GetNode(submenusPaths.Settings);
  }
}
