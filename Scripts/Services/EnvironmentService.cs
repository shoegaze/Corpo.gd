using System;
using System.IO;
using Corpo.Scripts.Services.Core;
using Godot;

namespace Corpo.Scripts.Services; 

public class EnvironmentService : Service {
  // TODO(spike): Generate this
  public struct EnvironmentJson {
    // TODO
  }

  public enum EnvironmentMode {
    Development = 0,
    Production = 1
  }
  
  public EnvironmentService() { }

  // Cannot be injected since this is a root Service
  private const string environmentFileNamePrefix = "environment";
  private const string environmentFileNameExtension = "json";

  public EnvironmentJson? Environment;

  public void LoadEnvironment(string fileName, EnvironmentMode mode) {
    // TODO(spike):
    // string fullFileName = $"{environmentFileNamePrefix}.{mode}.{environmentFileNameExtension}";
    // File file = new File(fullFileName);
    //
    // Environment = Json.Parse<EnvironmentJson>(file.ToString());
  }
}
