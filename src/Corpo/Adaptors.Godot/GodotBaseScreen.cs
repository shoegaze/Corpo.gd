using TeamSports.Screens;


namespace Corpo.Adaptors.Godot;


public abstract partial class GodotBaseScreen
    : GodotScreen, IBaseScreen<GameInput> {
  public abstract void SetupRoot();
}
