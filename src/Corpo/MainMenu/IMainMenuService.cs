using Corpo.Adaptors.Godot;

using Engine.Services;


namespace Corpo.MainMenu;


public interface IMainMenuService : IService {
  void ToggleSavesSubmenu(GodotScreen screen);
  void ToggleSettingsSubmenu(GodotScreen screen);
}
