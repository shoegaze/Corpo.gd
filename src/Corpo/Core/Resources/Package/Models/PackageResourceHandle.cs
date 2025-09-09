using TeamSports.Repositories.Handles;


namespace Corpo.Core.Resources.Package.Models;


public class PackageResourceHandle(
  string handle
) : ResourceHandle<PackageResourceHandleValidator>(handle);
