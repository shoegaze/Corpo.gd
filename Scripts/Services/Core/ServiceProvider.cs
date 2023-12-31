using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Godot;

namespace Corpo.Scripts.Services.Core;

public static class ServiceProvider {
  private static readonly List<Service> services = new();

  private static IEnumerable<Type> GetAllServiceSubclasses() {
    return Assembly
          .GetAssembly(typeof(Service))!
          .GetTypes()
          .Where(t => t.IsSubclassOf(typeof(Service)));
  }

  private static ConstructorInfo GetPrimaryConstructor(Type serviceType) {
    ConstructorInfo[] constructors = serviceType.GetConstructors();

    if (constructors.Length != 0) {
      return constructors.First();
    }

    GD.PrintErr($">>> Service \"{serviceType}\" should have a constructor!");
    throw new Exception("Service requires a constructor");
  }

  private static IEnumerable<Type> GetConstructorDependencies(Type serviceType) {
    return GetPrimaryConstructor(serviceType)
          .GetParameters()
          .Select(p => p.ParameterType);
  }

  private static ServiceDependencyGraph BuildDependencyGraph(IEnumerable<Type> serviceTypes) {
    Type[] serviceTypesCopy = serviceTypes.ToArray();
    ServiceDependencyGraph dependencyGraph = new(serviceTypesCopy);

    // We have to add dependencies before we get any back
    foreach (var serviceType in serviceTypesCopy) {
      GD.Print($" * Adding {serviceType}");

      Type[] dependencies = GetConstructorDependencies(serviceType).ToArray();

      foreach (Type dependency in dependencies) {
        GD.Print($"  - {dependency}");

        dependencyGraph.AddDependency(dependency, serviceType);
      }
    }

    return dependencyGraph;
  }

  private static void InstantiateService(Type serviceType) {
    GD.Print($" * Instantiating {serviceType}");

    ConstructorInfo constructor = GetPrimaryConstructor(serviceType);
    ParameterInfo[] parameterTypes = constructor.GetParameters();

    bool allParametersAreServiceSubclasses = parameterTypes
       .All(t => t.ParameterType.IsSubclassOf(typeof(Service)));

    // Only accept Service parameters
    if (!allParametersAreServiceSubclasses) {
      GD.PrintErr($">>> Service \"{serviceType}\" can only have parameters of type Service!");
      throw new Exception("Service can only have Service dependencies");
    }

    object[] parameters = constructor.GetParameters()
                                     .Select(p => p.ParameterType)
                                     .Select(Get) // Assume dependency is already loaded
                                     .ToArray();

    Service singleton = constructor.Invoke(parameters) as Service;
    services.Add(singleton);
  }

  public static void BuildServices() {
    GD.Print("Initializing Services ...");

    // try {
      GD.Print("> Generating dependency graph:");

      Type[] serviceTypes = GetAllServiceSubclasses().ToArray();
      ServiceDependencyGraph serviceDependencyGraph = BuildDependencyGraph(serviceTypes);

      Type[] sortedServiceTypes = serviceDependencyGraph.TopologicalSort()
                                                        .ToArray();

      GD.Print("> Topologically sorted dependencies:");
      foreach (Type serviceType in serviceTypes) {
        GD.Print($" * {serviceType}");
      }

      GD.Print("> Instantiating dependencies:");
      foreach (Type serviceType in sortedServiceTypes) {
        InstantiateService(serviceType);
      }

      GD.Print("> Complete!");
    // }
    // catch {
    //   GD.PrintErr("Could not initialize Services!");
    // }
  }

  private static object Get(Type serviceType) {
    Service service = services.Find(s => s.GetType() == serviceType);

    if (service == null) {
      GD.PrintErr($"Service \"{serviceType}\" could not be found!");
      throw new Exception("Service could not be found");
    }

    return service;
  }

  public static TS Get<TS>() where TS : Service {
    return Get(typeof(TS)) as TS;
  }
}
