using Corpo.Adaptors.Godot;

using TeamSports.Services;


namespace Corpo.MainMenu.Core;


public interface IMainMenuService : IService {
  void ToggleSavesSubmenu(IGodotScreen root);
  void ToggleSettingsSubmenu(IGodotScreen root);
}
