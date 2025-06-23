using Corpo.Base;

using TeamSports.Screens;


namespace Corpo.Adaptors.Godot.Screens;


public abstract partial class GodotBaseScreen<TInput>
    : GodotScreen<BaseRegistry, TInput>, IBaseScreen<TInput>
where TInput : struct {

  public abstract void SetupRoot();
}
