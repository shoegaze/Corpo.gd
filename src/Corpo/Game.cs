using Godot;

#if IMGUI
using ImGuiNET;
#endif


namespace Corpo;


public partial class Game : Node {
  public override void _Ready() => TestButton = GetNode<Button>("%TestButton");

  public void OnTestButtonPressed() => ButtonPresses++;

  public override void _Process(double dt) {
    #if IMGUI
    ImGui.Begin("Hello, ImGui!");
    ImGui.Text("This is the debug overlay");
    ImGui.End();
    #endif
  }
}
