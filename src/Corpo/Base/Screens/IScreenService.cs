using Corpo.Adaptors.Godot;

using Lamar;

using TeamSports.Services;


namespace Corpo.Base.Screens;


public interface IScreenService : IService {

  IGodotScreen CurrentScreen { get; }


  void UpdateScreen();
  void Enter<T>(GodotScreen<T> screen) where T : ServiceRegistry, new();
  void Dismiss();
}
