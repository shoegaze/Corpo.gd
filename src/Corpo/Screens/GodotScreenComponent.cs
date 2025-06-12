using Engine.Screens;


namespace Corpo.Screens;


public abstract class GodotScreenComponent : ScreenComponent<GameInput> {
  public abstract void Update(float dt);
  public abstract void Tick(float dt, GameInput? input);
}
