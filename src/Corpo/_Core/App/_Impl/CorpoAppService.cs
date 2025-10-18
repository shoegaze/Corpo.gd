using Corpo._App;
using Corpo._App.Providers;


namespace Corpo._Core.App._Impl;


public class CorpoAppService : ICorpoAppService {
  public CorpoProvidersAggregate Providers { get; }

  public CorpoApp GetApp() {
    throw new System.NotImplementedException();
  }
}
