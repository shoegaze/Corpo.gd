using GdUnit4.Api;


namespace GdUnit4.TestAdapter;


public partial class TestAdapterRunner : TestRunner {
  public override void _Ready() {
    _ = RunTests();
  }
}
