using System;
using System.Collections.Generic;
using System.IO;

using Corpo.Base.Environments;
using Corpo.Loading.Core.Models;


namespace Corpo.Base.Resources.Implementations;


// ReSharper disable once ClassNeverInstantiated.Global
public sealed class PackageResourcesService(
  IEnvironmentService environmentService
) : IPackageResourcesService {

  // TODO: HashSet<PackageHandle, PackageInfo>
  private readonly Dictionary<string, PackageInfo> packagesInfo = new();

  public void LoadPackage(LoadPackageContext packageContext) {
    string packagePath = packageContext.GetPathFromRoot();

    // TODO: Get file names/patterns from env
    string metaPath = Path.Combine(packagePath, "about.json");
    string readmePath = Path.Combine(packagePath, "README.md");
    string licensePath = Path.Combine(packagePath, "LICENSE");

    // TODO: Verify paths
    // TODO: Verify+load file contents

    var meta = "TODO";    // TODO: File.Read(metaPath)
    var readme = "TODO";  // TODO: File.Read(readmePath)
    var license = "TODO"; // TODO: File.Read(licensePath)

    string handle = GetHandle(packageContext);
    var packageInfo = new PackageInfo(meta, readme, license);

    AddPackage(handle, packageInfo);
  }

  private string GetHandle(LoadPackageContext packageContext) {
    string template = environmentService.Environment.Handle.Resource.Package;
    (string root, string author, string package) = packageContext;

    return string.Format(template, root, author, package);
  }

  private void AddPackage(string handle, PackageInfo packageInfo) {
    throw new NotImplementedException();
  }

  private record PackageInfo(
    string Meta,
    string Readme,
    string License
  );
}
