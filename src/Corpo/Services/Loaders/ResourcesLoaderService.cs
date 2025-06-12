using System.IO;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

using Godot;

using Engine.Services;

using Corpo.Services.Environment;
using Corpo.Services.Loaders.Models;


namespace Corpo.Services.Loaders;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ResourcesLoaderService(
  EnvironmentService environmentService,
  PackageResourcesService packageResourcesService,
  SharedResourcesService sharedResourcesService,
  OverworldResourcesService overworldResourcesService,
  BattleResourcesService battleResourcesService
)
    : Service {
  private readonly OverworldResourcesService overworldResourcesService = overworldResourcesService;


  public /*async*/ void LoadAll() {
    // TODO(shoegaze): Environment/SettingsService.FromPath(...)
    string packagesRoot = ProjectSettings.GlobalizePath(
      environmentService.Environment.Path.Package.Root);

    var rootContext = new LoaderContext(packagesRoot);

    LoadPackages(rootContext);
  }

  private void LoadPackages(LoaderContext rootContext) {
    // ReSharper disable once InlineTemporaryVariable
    string root = rootContext.GetPathFromRoot();

    var authorsMatcher = new Matcher();
    authorsMatcher.AddInclude("*/");

    PatternMatchingResult result = authorsMatcher.Execute(
      new DirectoryInfoWrapper(
        new DirectoryInfo(root)));

    foreach (FilePatternMatch match in result.Files) {
      string author = match.Path;
      var ctx = new LoadAuthorContext(root, author);

      LoadAuthor(ctx);
    }
  }

  private void LoadAuthor(LoadAuthorContext authorContext) {
    string root = authorContext.GetPathFromRoot();

    var packagesMatcher = new Matcher();
    packagesMatcher.AddInclude("*/");

    PatternMatchingResult result = packagesMatcher.Execute(
      new DirectoryInfoWrapper(
        new DirectoryInfo(root)));

    foreach (FilePatternMatch match in result.Files) {
      string package = match.Path;

      var packageContext = new LoadPackageContext(
        authorContext.Root,
        authorContext.Author,
        package);

      LoadPackage(packageContext);
    }
  }

  private void LoadPackage(LoadPackageContext packageContext) {
    packageResourcesService.LoadPackage(packageContext);

    LoadSharedAssets(packageContext);
    // TODO(shoegaze): Defer until entering OverworldScreen?
    LoadOverworldAssets(packageContext);
    // TODO(shoegaze): Defer until entering BattleScreen?
    LoadBattleAssets(packageContext);
  }

  private void LoadSharedAssets(LoadPackageContext packageContext) {
    string sharedRoot = environmentService.Environment.Path.Package.Shared;

    LoadSharedResourcesContext sharedContext = LoadSharedResourcesContext.From(
      packageContext,
      sharedRoot);

    sharedResourcesService.LoadAssets(sharedContext);
  }

  private void LoadOverworldAssets(LoadPackageContext packageContext) {
    string overworldRoot = environmentService.Environment.Path.Package.Overworld;
  }

  private void LoadBattleAssets(LoadPackageContext packageContext) {
    string battleRoot = environmentService.Environment.Path.Package.Battle;

    LoadBattleResourcesContext battleContext = LoadBattleResourcesContext.From(
      packageContext,
      battleRoot);

    battleResourcesService.LoadAssets(battleContext);
  }
}
