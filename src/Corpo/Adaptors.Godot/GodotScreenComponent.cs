using TeamSports.Screens;


namespace Corpo.Adaptors.Godot;


public abstract class GodotScreenComponent : ScreenComponent<CorpoInput> {
  public abstract void Update(float dt);
  public abstract void Tick(float dt, CorpoInput? input);
}
