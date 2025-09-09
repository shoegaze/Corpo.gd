using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Entities.Screens;
#if IMGUI
using ImGuiNET;
#endif


namespace Corpo.MainMenu.Debug._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuDebugScreen : IMainMenuDebugScreen {

  public override string ToString() {
    return GetName();
  }

  public string GetName() {
    return nameof(MainMenuDebugScreen);
  }

  public void Initialize() {
    // TODO
  }

  public void DrawDebug(float dt, CorpoInput input) {
#if IMGUI
    ImGui.Begin("Starting debug screen");
    ImGui.Text("Hello, world!");
    ImGui.End();
#endif
  }

  public void OnCreate() { }

  public void OnDestroy() {
    throw new System.NotImplementedException();
  }

  public void OnMount() {
    throw new System.NotImplementedException();
  }

  public void OnUnmount() {
    throw new System.NotImplementedException();
  }

  public void OnFocusIn(IScreen<CorpoInput> from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(float dt, CorpoInput input) { }

}
