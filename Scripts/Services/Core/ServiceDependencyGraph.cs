using System;
using System.Collections.Generic;
using System.Linq;

namespace Corpo.Scripts.Services.Core;

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

  private ServiceDependencyGraph(ServiceDependencyGraph serviceDependencyGraph) {
    Graph = new Dictionary<Type, List<Type>>(serviceDependencyGraph.Graph);
  }

  private void AddType(Type type) {
    if (Graph.ContainsKey(type)) {
      return;
    }

    Graph.Add(type, new List<Type>());
  }

  public void AddDependency(Type from, Type to) {
    if (!Graph.ContainsKey(from)) {
      Graph.Add(from, new List<Type>());
    }

    Graph[from].Add(to);
  }

  private void RemoveDependency(Type from, Type to) {
    if (!Graph.ContainsKey(from)) {
      return;
    }

    Graph[from].Remove(to);
  }

  private IEnumerable<Type> GetRoots() {
    return Graph.Keys
                .Where(s => !GetDependencies(s).Any());
  }

  public IEnumerable<Type> GetDependencies(Type type) {
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
