using Engine.Repositories;


namespace Corpo.Base.Resources.Package.Models;


public class PackageResourceHandle(
  string handle
) : ResourceHandle<PackageResourceHandleValidator>(handle);
