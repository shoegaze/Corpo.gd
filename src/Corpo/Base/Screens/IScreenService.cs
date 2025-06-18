using Corpo.Adaptors.Godot;

using TeamSports.Services;


namespace Corpo.Base.Screens;


public interface IScreenService : IService {

  GodotScreen CurrentScreen { get; }


  void UpdateScreen();
  void Enter(GodotScreen screen);
  void Dismiss();
}
