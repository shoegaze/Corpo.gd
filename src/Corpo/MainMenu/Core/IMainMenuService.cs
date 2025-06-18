using Corpo.Adaptors.Godot;

using TeamSports.Services;


namespace Corpo.MainMenu.Core;


public interface IMainMenuService : IService {
  void ToggleSavesSubmenu(GodotScreen screen);
  void ToggleSettingsSubmenu(GodotScreen screen);
}
