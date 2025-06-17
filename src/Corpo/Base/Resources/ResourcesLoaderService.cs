using System.IO;

using Corpo.Base.Environments;
using Corpo.Loading;

using Godot;

using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;


namespace Corpo.Base.Resources;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class ResourcesLoaderService(
  IEnvironmentService environmentService,
  IPackageResourcesService packageResourcesService,
  ISharedResourcesService sharedResourcesService
) : IResourcesLoaderService {

  public void LoadAll() {
    // TODO: Environment/SettingsService.FromPath(...)
    string packagesRoot =
        ProjectSettings.GlobalizePath(
          environmentService.Environment.Path.Package.Root);

    var rootContext = new LoaderContext(packagesRoot);

    LoadPackages(rootContext);
  }

  private void LoadPackages(LoaderContext rootContext) {
    // ReSharper disable once InlineTemporaryVariable
    string root = rootContext.GetPathFromRoot();

    var authorsMatcher = new Matcher();
    authorsMatcher.AddInclude("*/");

    PatternMatchingResult result =
        authorsMatcher.Execute(
          new DirectoryInfoWrapper(new DirectoryInfo(root)));

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

    PatternMatchingResult result =
        packagesMatcher.Execute(
          new DirectoryInfoWrapper(new DirectoryInfo(root)));

    foreach (FilePatternMatch match in result.Files) {
      string package = match.Path;

      var packageContext =
          new LoadPackageContext(
            authorContext.Root,
            authorContext.Author,
            package);

      LoadPackage(packageContext);
    }
  }

  private void LoadPackage(LoadPackageContext packageContext) {
    packageResourcesService.LoadPackage(packageContext);

    LoadSharedAssets(packageContext);
  }

  private void LoadSharedAssets(LoadPackageContext packageContext) {
    string sharedRoot = environmentService.Environment.Path.Package.Shared;

    LoadSharedResourcesContext sharedContext =
        LoadSharedResourcesContext.From(
          packageContext,
          sharedRoot);

    sharedResourcesService.LoadAssets(sharedContext);
  }
}
