using System;
using System.Collections.Generic;
using System.IO;

using Corpo.Services.Asset.Models;
using Corpo.Services.Core;
using Corpo.Services.Environment;
using Corpo.Services.Log;

namespace Corpo.Services.Asset;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class PackageResourcesService : Service {
  private readonly EnvironmentService environmentService;
  private readonly LoggerService loggerService;

  // TODO(shoegaze): HashSet<PackageHandle, PackageInfo>
  private readonly Dictionary<string, PackageInfo> packagesInfo = new();

  public PackageResourcesService(
    EnvironmentService environmentService,
    LoggerService loggerService
  ) {
    this.environmentService = environmentService;
    this.loggerService = loggerService;
  }

  public void LoadPackage(LoadPackageContext packageContext) {
    string packagePath = packageContext.GetPathFromRoot();

    // TODO(shoegaze): Get file names/patterns from env
    string metaPath = Path.Combine(packagePath, "about.json");
    string readmePath = Path.Combine(packagePath, "README.md");
    string licensePath = Path.Combine(packagePath, "LICENSE");

    // TODO(shoegaze): Verify paths
    // TODO(shoegaze): Verify+load file contents

    string meta = "TODO";// TODO(shoegaze): File.Read(metaPath)
    string readme = "TODO";// TODO(shoegaze): File.Read(readmePath)
    string license = "TODO";// TODO(shoegaze): File.Read(licensePath)

    string handle = GetHandle(packageContext);
    var packageInfo = new PackageInfo(meta, readme, license);

    AddPackage(handle, packageInfo);
  }

  private string GetHandle(LoadPackageContext packageContext) {
    string template = environmentService.Environment.Handles.PackageResource;
    (string root, string author, string package) = packageContext;

    return string.Format(template, root, author, package);
  }

  private void AddPackage(string handle, PackageInfo packageInfo) {
    // TODO(shoegaze);
    throw new NotImplementedException("TODO");

    if (packagesInfo.TryAdd(handle, packageInfo)) {
      return;
    }

    loggerService.Error($"Package handle collision detected: {handle}");
  }

  private record PackageInfo(
    string Meta,
    string Readme,
    string License
  );
}
