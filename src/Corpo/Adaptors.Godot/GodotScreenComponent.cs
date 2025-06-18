using TeamSports.Screens;


namespace Corpo.Adaptors.Godot;


public abstract class GodotScreenComponent : ScreenComponent<GameInput> {
  public abstract void Update(float dt);
  public abstract void Tick(float dt, GameInput? input);
}
