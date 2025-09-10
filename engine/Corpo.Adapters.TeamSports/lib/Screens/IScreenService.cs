using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Adapters.Godot.Services;


namespace Corpo.Adapters.TeamSports.Screens;


public interface IScreenService<in TScreen>
  : IGodotScreenService<TScreen, CorpoInput>
where TScreen : IScreen;
