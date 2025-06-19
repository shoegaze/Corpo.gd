using Corpo.Adaptors.Godot;

using Lamar;

using TeamSports;


namespace Corpo.Loading;


public partial class LoadingScreen : GodotScreen {
  private Container loadingContainer;

  private ILogger logger;

  public override string ToString() {
    return nameof(LoadingScreen);
  }


  public override Container Services => loadingContainer;


  public override void OnCreate() {
    loadingContainer = BuildContainer<LoadingRegistry>(logger);
    logger = loadingContainer.GetInstance<ILogger>();
  }

  public override void OnFocus() { }

  public override void OnDismiss() { }

  public override void Tick(float dt, GameInput? input) { }
}
