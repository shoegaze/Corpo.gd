using System.Reflection;


namespace Engine.Services;


public static class ServiceProvider {
  private static readonly List<Service> Services = [];

  private static IEnumerable<Type> GetAllServiceSubclasses(Assembly assembly) {
	return assembly
	   .GetTypes()
	   .Where(t => t.IsSubclassOf(typeof(Service)));
  }

  private static ConstructorInfo GetPrimaryConstructor(Type serviceType) {
	ConstructorInfo[] constructors = serviceType.GetConstructors();

	if (constructors.Length != 0) {
	  return constructors.First();
	}

	// GD.PrintErr($">>> Service \"{serviceType}\" should have a constructor!");

	throw new Exception("Service requires a constructor");
  }

  private static IEnumerable<Type> GetConstructorDependencies(Type serviceType) {
	return GetPrimaryConstructor(serviceType)
	   .GetParameters()
	   .Select(p => p.ParameterType);
  }

  private static ServiceDependencyGraph BuildDependencyGraph(
	IEnumerable<Type> serviceTypes
  ) {
	List<Type> serviceTypesCopy = serviceTypes.ToList();
	ServiceDependencyGraph dependencyGraph = new(serviceTypesCopy);

	// We have to add dependencies before we get any back
	foreach (Type serviceType in serviceTypesCopy) {
	  // GD.Print($" * Adding {serviceType}");

	  Type[] dependencies = GetConstructorDependencies(serviceType).ToArray();

	  foreach (Type dependency in dependencies) {
		// GD.Print($"  - {dependency}");

		dependencyGraph.AddDependency(dependency, serviceType);
	  }
	}

	return dependencyGraph;
  }

  private static void InstantiateService(Type serviceType) {
	// GD.Print($" * Instantiating {serviceType}");

	ConstructorInfo constructor = GetPrimaryConstructor(serviceType);
	ParameterInfo[] parameterTypes = constructor.GetParameters();

	bool allParametersAreServiceSubclasses =
		parameterTypes
		   .All(t => t.ParameterType.IsSubclassOf(typeof(Service)));

	// Only accept Service parameters
	if (!allParametersAreServiceSubclasses) {
	  // GD.PrintErr(
	  //       $">>> Service \"{serviceType}\" can only have parameters of type Service!"
	  //     );

	  throw new Exception(
			$"Services may only have Service dependencies in constructor parameter: {serviceType}"
		  );
	}

	object[] parameters =
		constructor.GetParameters()
		   .Select(p => p.ParameterType)
		   .Select(Get) // Assume dependency is already loaded
		   .ToArray();

	if (constructor.Invoke(parameters) is not Service singleton) {
	  throw new Exception($"Constructor invocation error, could not create Service: {serviceType}");
	}

	Services.Add(singleton);
  }

  public static void BuildServices(Assembly assembly) {
	// GD.Print("Initializing Services ...");

	try {
	  // GD.Print("> Generating dependency graph:");

	  List<Type> serviceTypes = GetAllServiceSubclasses(assembly).ToList();
	  ServiceDependencyGraph serviceDependencyGraph = BuildDependencyGraph(serviceTypes);

	  List<Type> sortedServiceTypes =
		  serviceDependencyGraph
			 .TopologicalSort()
			 .ToList();

	  // GD.Print("> Topologically sorted dependencies:");
	  //
	  // foreach (Type serviceType in serviceTypes) {
	  //   GD.Print($" * {serviceType}");
	  // }
	  //
	  // GD.Print("> Instantiating dependencies:");

	  foreach (Type serviceType in sortedServiceTypes) {
		InstantiateService(serviceType);
	  }

	  // GD.Print("> Complete!");
	}
	catch {
	  // GD.PrintErr("Could not initialize Services!");
	  throw new Exception("Could not initialize Services!");
	}
  }

  private static object Get(Type serviceType) {
	Service? service = Services.Find(s => s.GetType() == serviceType);

	if (service == null) {
	  // GD.PrintErr($"Service \"{serviceType}\" could not be found!");

	  throw new Exception($"Service could not be found: {serviceType}");
	}

	return service;
  }

  public static TS? Get<TS>() where TS : Service {
	return Get(typeof(TS)) as TS;
  }
}
