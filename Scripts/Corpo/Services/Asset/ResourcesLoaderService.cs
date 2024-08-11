using System.IO;

using Corpo.Services.Asset.Models;
using Corpo.Services.Core;
using Corpo.Services.Environment;

using Godot;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace Corpo.Services.Asset;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ResourcesLoaderService : Service {
  private readonly BattleResourcesService battleResourcesService;
  private readonly EnvironmentService environmentService;
  private readonly OverworldResourcesService overworldResourcesService;
  private readonly PackageResourcesService packageResourcesService;
  private readonly SharedResourcesService sharedResourcesService;

  public ResourcesLoaderService(
    EnvironmentService environmentService,
    PackageResourcesService packageResourcesService,
    SharedResourcesService sharedResourcesService,
    OverworldResourcesService overworldResourcesService,
    BattleResourcesService battleResourcesService
  ) {
    this.environmentService = environmentService;
    this.packageResourcesService = packageResourcesService;
    this.sharedResourcesService = sharedResourcesService;
    this.overworldResourcesService = overworldResourcesService;
    this.battleResourcesService = battleResourcesService;
  }

  public /*async*/ void LoadAll() {
    // TODO(shoegaze): Environment/SettingsService.FromPath(...)
    string packagesRoot = ProjectSettings.GlobalizePath(
      environmentService.Environment.Paths.Packages.Root);

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
    string sharedRoot = environmentService.Environment.Paths.Packages.Shared;

    LoadSharedResourcesContext sharedContext = LoadSharedResourcesContext.From(
      packageContext,
      sharedRoot);

    sharedResourcesService.LoadAssets(sharedContext);
  }

  private void LoadOverworldAssets(LoadPackageContext packageContext) {
    string overworldRoot = environmentService.Environment.Paths.Packages.Overworld;
  }

  private void LoadBattleAssets(LoadPackageContext packageContext) {
    string battleRoot = environmentService.Environment.Paths.Packages.Battle;

    LoadBattleResourcesContext battleContext = LoadBattleResourcesContext.From(
      packageContext,
      battleRoot);

    battleResourcesService.LoadAssets(battleContext);
  }
}
