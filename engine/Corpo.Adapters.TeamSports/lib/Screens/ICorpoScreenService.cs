using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Services;


namespace Corpo.Adapters.TeamSports.Screens;


public interface ICorpoScreenService<in TScreen>
  : IGodotScreenService<TScreen, CorpoInput>
where TScreen : ICorpoScreen;
