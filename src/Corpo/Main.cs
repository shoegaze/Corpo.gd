using System.Reflection;

using Chickensoft.GameTools.Displays;
using Chickensoft.GodotNodeInterfaces;
using Chickensoft.GoDotTest;

using Godot;


namespace Corpo;


public partial class Main : Node {
  public Vector2I DesignResolution => Display.UHD4k;

  #if RUN_TESTS
  public TestEnvironment Environment = default!;
  #endif

  public override void _Ready() {
    // Correct any erroneous scaling and guess sensible defaults.
    GetWindow().LookGood(WindowScaleBehavior.UIFixed, DesignResolution);

    #if RUN_TESTS
    // If this is a debug build, use GoDotTest to examine the
    // command line arguments and determine if we should run tests.
    Environment = TestEnvironment.From(OS.GetCmdlineArgs());

    if (Environment.ShouldRunTests) {
      RuntimeContext.IsTesting = true;
      CallDeferred(nameof(RunScene));

      return;
    }
    #endif

    // If we don't need to run tests, we can just switch to the game scene.
    CallDeferred(nameof(RunScene));
  }

  #if RUN_TESTS
  private void RunTests() =>
    _ = GoTest.RunTests(Assembly.GetExecutingAssembly(), this, Environment);
  #endif

  private void RunScene() => GetTree().ChangeSceneToFile("res://src/Game.tscn");
}
