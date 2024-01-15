using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;

namespace Corpo.Scripts.Services.Screen; 

// ReSharper disable once ClassNeverInstantiated.Global
public class MainMenuService : Service {
  private readonly EnvironmentService environmentService;
  
  public MainMenuService(EnvironmentService environmentService) {
    this.environmentService = environmentService;
  }
  
  public void ToggleSavesSubmenu(Screens.Core.Screen root) {
    var submenusPaths = environmentService.Environment.Paths.Screens.MainMenu.Submenus;
    var submenusRoot = root.GetNode(submenusPaths.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO(spike): Fade out animation
      submenusRoot!.Visible = false;
      return;
    }

    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 0;

    var subMenuSave = submenusRoot!.GetNode(submenusPaths.Saves);
    
    // TODO(spike): Set up saves UI
  }

  public void ToggleSettingsSubmenu(Screens.Core.Screen root) {
    var submenusPaths = environmentService.Environment.Paths.Screens.MainMenu.Submenus;
    var submenusRoot = root.GetNode(submenusPaths.Root) as TabContainer;

    if (submenusRoot!.Visible) {
      // TODO(spike): Fade out animation
      submenusRoot!.Visible = false;
      return;
    }
    
    submenusRoot!.Visible = true;
    submenusRoot!.CurrentTab = 1;
    
    var subMenuSettings = submenusRoot!.GetNode(submenusPaths.Settings);
    
    // TODO(spike): Set up settings UI
  }
}
