using System.Collections.Generic;
using Corpo.Scripts.Services;
using Godot;

namespace Corpo.Scripts; 

public static class ServiceProvider {
  private static readonly List<Service> Services = new();

  static ServiceProvider() {
    // TODO(spike): Automate registration
    //  1. Use reflection to get all children of `Service`
    //  2. Initialize all children => Requires default constructor
    //  3. Add children to `Services` list
    
    Services.Add(new BaseService());
    Services.Add(new BattleService());
    Services.Add(new LoadingService());
    Services.Add(new OverworldService());
    Services.Add(new ScreenService());
    Services.Add(new StateService());
  }

  public static TS Get<TS>() where TS : Service {
    Service service = Services.Find(s => s.GetType() == typeof(TS));

    if (service == null) {
      GD.PrintErr($"Service of type \"{typeof(TS)}\" could not be found!");
    }
    
    return service as TS;
  }
}
