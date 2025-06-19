using Corpo.Adaptors.Godot;


namespace Corpo.Loading;


public partial class LoadingScreen : GodotScreen<LoadingRegistry> {
  public override string ToString() {
    return nameof(LoadingScreen);
  }
}
