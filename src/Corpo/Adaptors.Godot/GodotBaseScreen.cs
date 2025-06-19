using Corpo.Base;

using TeamSports.Screens;


namespace Corpo.Adaptors.Godot;


public abstract partial class GodotBaseScreen
    : GodotScreen<BaseRegistry>, IBaseScreen<CorpoInput> {
  public abstract void SetupRoot();
}
