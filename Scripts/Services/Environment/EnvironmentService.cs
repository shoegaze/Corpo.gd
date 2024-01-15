using System;
using System.IO;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment.Json;
using Godot;
using Newtonsoft.Json;
using QuickType;

namespace Corpo.Scripts.Services.Environment;

// ReSharper disable once ClassNeverInstantiated.Global
public class EnvironmentService : Service {
  public enum EnvironmentMode {
    Development = 0,
    Production = 1
  }

  // Cannot be injected since this is a root Service
  private const string environmentFileNamePrefix = "environment";
  private const string environmentFileNameExtension = "json";

  public TopLevel Environment { get; private set; }

  private static string MapEnvironmentModeToFileNameFragment(EnvironmentMode mode) {
    return mode switch {
             EnvironmentMode.Development => "dev",
             EnvironmentMode.Production => "prod",
             _ => throw new Exception("Environment mode not supported")
           };
  }

  public void LoadEnvironment(string rootPath, EnvironmentMode mode) {
    string modeName = MapEnvironmentModeToFileNameFragment(mode);
    string fullFileName = $"{environmentFileNamePrefix}.{modeName}.{environmentFileNameExtension}";
    string fullFilePath = Path.Combine(rootPath, fullFileName);

    GD.Print("Loading environment file ...");
    GD.Print($" * {fullFilePath}");
    
    using StreamReader reader = new StreamReader(fullFilePath);
    string jsonString = reader.ReadToEnd();
    
    // TODO(spike): Validate JSON object from schema
    Environment = TopLevel.FromJson(jsonString);
    
    GD.Print("> Complete!");
  }
}
