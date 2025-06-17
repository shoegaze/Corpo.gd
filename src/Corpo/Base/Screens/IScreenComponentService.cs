using Corpo.Adaptors.Godot;

using Engine.Services;


namespace Corpo.Base.Screens;


public interface IScreenComponentService : IService {
  GodotScreenComponent CurrentComponent { get; }


  int Add(GodotScreenComponent component);
  void RemoveAll();
  void Seek(int index);
  void Tick(float dt);
}
