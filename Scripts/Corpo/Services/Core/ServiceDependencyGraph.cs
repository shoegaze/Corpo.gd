using System;
using System.Collections.Generic;
using System.Linq;

using Godot;


namespace Corpo.Services.Core;

// { ServiceType: [ ServiceType ] } = { from: [to] }
public sealed class ServiceDependencyGraph {

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

  private Dictionary<Type, List<Type>> Graph { get; }

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
                .Where(s => !GetDependents(s).Any());
  }

  private IEnumerable<Type> GetDependents(Type type) {
    return Graph.Keys
                .Where(t => Graph
                           .GetValueOrDefault(t, new List<Type>())
                           .Contains(type));
  }

  public IEnumerable<Type> TopologicalSort() {
    ServiceDependencyGraph dg = new(this);
    Stack<Type> toVisit = new();

    GD.Print("Initial roots: ");

    foreach (Type root in dg.GetRoots()) {
      GD.Print($">> {root}");

      toVisit.Push(root);
    }

    List<Type> sorted = new();

    {
      int iterations = 0;
      int maxIterations = dg.Graph.Count;

      while (iterations < maxIterations) {
        while (toVisit.Any()) {
          Type from = toVisit.Pop();
          sorted.Add(from);

          IEnumerable<Type> dependents = dg.GetDependents(from);

          foreach (Type to in dependents) {
            dg.RemoveDependency(from, to);
          }

          dg.Graph.Remove(from);
        }

        // Regenerate `toVisit`s
        // TODO(shoegaze): Do a linear search/cache instead of creating a new set with `GetRoots`
        foreach (Type root in dg.GetRoots()) {
          toVisit.Push(root);
        }

        if (toVisit.Count == 0) {
          break;
        }

        iterations++;
      }
    }

    // WARN: Only possible if all nodes are present in graph.Keys
    if (sorted.Count != Graph.Count) {
      throw new Exception("The provided graph is not valid. Possibly cyclic?");
    }

    return sorted;
  }
}
