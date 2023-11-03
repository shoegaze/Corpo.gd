using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Corpo.Scripts.Services;
using Godot;

namespace Corpo.Scripts; 

public static class ServiceProvider {
  private static readonly List<Service> Services = new();

  static ServiceProvider() {
    GD.Print("Initializing Services...");
    
    // Get all subclasses of `Service`
    IEnumerable<Type> serviceTypes = Assembly
                                    .GetAssembly(typeof(Service))!
                                    .GetTypes()
                                    .Where(t => t.IsSubclassOf(typeof(Service)));
    
    // Initialize all services and add to `Services` list
    foreach (Type serviceType in serviceTypes) {
      GD.Print($"> {serviceType}");

      ConstructorInfo constructor = serviceType.GetConstructor(Array.Empty<Type>());

      if (constructor == null) {
        GD.PrintErr($">> Service \"{serviceType}\" should have a default constructor!");
        return;
      }

      var singleton = constructor.Invoke(Array.Empty<object>()) as Service;
      Services.Add(singleton);
      
      GD.Print(">> Loaded successfully");
    }
  }

  public static TS Get<TS>() where TS : Service {
    Service service = Services.Find(s => s.GetType() == typeof(TS));

    if (service == null) {
      GD.PrintErr($"Service \"{typeof(TS)}\" could not be found!");
    }
    
    return service as TS;
  }
}
