using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpo.Scripts;

// { ServiceType: [ ServiceType ] } = { from: [to] }
public class ServiceDependencyGraph {
  private Dictionary<Type, List<Type>> Graph { get; }

  public ServiceDependencyGraph(IEnumerable<Type> serviceTypes) {
    Graph = new Dictionary<Type, List<Type>>();

    // Register all service types to graph
    //  Needed for disconnected services with outdegree 1
    //  i.e. Asserts all nodes are present in graph
    foreach (Type serviceType in serviceTypes) {
      AddType(serviceType);
    }
  }

  public ServiceDependencyGraph(ServiceDependencyGraph serviceDependencyGraph) {
    Graph = new Dictionary<Type, List<Type>>(serviceDependencyGraph.Graph);
  }

  public bool AddType(Type type) {
    if (Graph.ContainsKey(type)) {
      return false;
    }

    Graph.Add(type, new List<Type>());

    return true;
  }

  public void AddDependency(Type from, Type to) {
    if (!Graph.ContainsKey(from)) {
      Graph.Add(from, new List<Type>());
    }

    List<Type> dependents = Graph[from];
    dependents.Add(to);
  }

  private bool RemoveDependency(Type from, Type to) {
    if (!Graph.ContainsKey(from)) {
      return false;
    }

    return Graph[from].Remove(to);
  }

  private IEnumerable<Type> GetRoots() {
    return Graph.Keys
                .Where(s => !GetDependencies(s).Any());
  }

  public IEnumerable<Type> GetDependencies(Type type) {
    // TODO(spike): Verify this
    return Graph.Keys
                .Where(t => 
                           Graph
                           .GetValueOrDefault(t, new List<Type>())
                           .Contains(t));
  }

  public IEnumerable<Type> TopologicalSort() {
    ServiceDependencyGraph dg = new(this);
    Stack<Type> toVisit = new();

    { // Initialize `toVisit` stack
      IEnumerable<Type> roots = dg.GetRoots();

      foreach (Type root in roots) {
        toVisit.Push(root);
      }
    }

    List<Type> sorted = new();

    while (toVisit.Count > 0) {
      Type from = toVisit.Pop();
      sorted.Add(from);

      IEnumerable<Type> dependents = GetDependencies(from);

      foreach (var to in dependents) {
        dg.RemoveDependency(from, to);

        // TODO(spike): Do a linear search/cache instead of creating a new set with `GetRoots`
        IEnumerable<Type> roots = dg.GetRoots();

        if (roots.Contains(to)) {
          toVisit.Push(to);
        }
      }
    }

    // WARN: Only possible if all nodes are present in graph.Keys
    if (sorted.Count != Graph.Keys.Count) {
      throw new Exception("The provided graph is not valid. Possibly cyclic?");
    }
    
    sorted.Reverse();
    
    return sorted;
  }
}
