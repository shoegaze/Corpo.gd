using Corpo.Adaptors.Godot;


namespace Corpo.Overworld;


public sealed partial class OverworldScreen : GodotScreen<OverworldRegistry> {
  public override string ToString() {
    return nameof(OverworldScreen);
  }
}
