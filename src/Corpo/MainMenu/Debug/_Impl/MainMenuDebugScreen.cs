using Corpo.Adapters.TeamSports.Input.Concrete;

using TeamSports.Core.Entities.Screens;

#if IMGUI
using ImGuiNET;
#endif


namespace Corpo.MainMenu.Debug._Impl;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MainMenuDebugScreen : IMainMenuDebugScreen {

  public override string ToString() {
    return GetEntityName();
  }

  public string GetEntityName() {
    return nameof(MainMenuDebugScreen);
  }

  public void DrawDebug(float dt, CorpoUserInput userInput) {
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

  public void OnFocusIn(IScreen<CorpoUserInput> from) {
    throw new System.NotImplementedException();
  }

  public void OnFocusOut(IScreen<CorpoUserInput> to) {
    throw new System.NotImplementedException();
  }

  public void Tick(double dt, CorpoUserInput userInput) {
    throw new System.NotImplementedException();
  }

  public void Pause() {
    throw new System.NotImplementedException();
  }

  public void Unpause() {
    throw new System.NotImplementedException();
  }
}
