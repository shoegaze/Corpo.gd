// ReSharper disable UnusedMember.Global

using GdUnit4;


namespace Corpo.CorpoTest;


using static Assertions;


[TestSuite]
public class ExampleTest {
  [TestCase]
  public void SimpleAddition() {
    AssertInt(1 + 1).IsEqual(2);
  }
}
