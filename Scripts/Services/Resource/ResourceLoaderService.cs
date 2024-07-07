using System.IO;
using Corpo.Scripts.Services.Core;
using Corpo.Scripts.Services.Environment;
using Godot;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace Corpo.Scripts.Services.Resource; 

// ReSharper disable once ClassNeverInstantiated.Global
public class ResourceService : Service {
  private readonly EnvironmentService environmentService;

  // private readonly HashSet<string> handles = new();

  public ResourceService(
    EnvironmentService environmentService
    // TODO(spike): Inject resource-type specific loader services
  ) {
    this.environmentService = environmentService;
  }

  public async void LoadAll() {
    string packagesRoot = ProjectSettings.GlobalizePath(
      environmentService.Environment.Paths.Packages);
    
    LoadPackages(packagesRoot);
  }

  private void LoadPackages(string packagesRoot) {
    string root = packagesRoot;
    
    var authorsMatcher = new Matcher();
    authorsMatcher.AddInclude("*/");

    var result = authorsMatcher.Execute(
          new DirectoryInfoWrapper(
                new DirectoryInfo(root)));

    foreach (var match in result.Files) {
      string author = match.Path;
      LoadAuthor(packagesRoot, author);
    }
  }

  private void LoadAuthor(string packagesRoot, string author) {
    string root = Path.Combine(packagesRoot, author);

    var packagesMatcher = new Matcher();
    packagesMatcher.AddInclude("*/");

    var result = packagesMatcher.Execute(
      new DirectoryInfoWrapper(
        new DirectoryInfo(root)));

    foreach (var match in result.Files) {
      string package = match.Path;
      LoadPackage(packagesRoot, author, package);   
    }
  }

  private void LoadPackage(string packagesRoot, string author, string package) {
    string root = Path.Combine(packagesRoot, author, package);
    
    // TODO;
    // this.packageResourceService.LoadPackage(packagesRoot, author, package) { 
    //    // TODO: Get file names from env
    //    string metaPath = $"{root}/about.json";
    //    string readmePath = $"{root}/README";
    //    string licensePath = $"{root}/LICENSE";
    //    
    //    var packageInfo = new PackageInfo(meta, readme, license);
    //    this.packageResourceService.AddPackage(author, package, packageInfo);
    //  }

    string otherPath = $"{root}/Other/";
    // LoadOtherResources(packagesRoot, author, package);
    
    string overworldPath = $"{root}/Overworld/";
    // LoadOverworldResources(packagesRoot, author, package);
    
    string battlePath = $"{root}/Overworld/";
    // LoadBattleResources(packagesRoot, author, package);
    
  }
}
