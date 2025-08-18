using System.Collections.Generic;

using Corpo.Adapters.Services;


namespace Corpo.Adaptors.Concrete;


public class CorpoStartableTracker {
  public List<ICorpoStartable> Startables { get; } = [];
}
