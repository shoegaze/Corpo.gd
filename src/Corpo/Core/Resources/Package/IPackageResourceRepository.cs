using Corpo.Core.Resources.Package.Models;

using TeamSports.Repositories;


namespace Corpo.Core.Resources.Package;


public interface IPackageResourceRepository
  : IRepository<IPackageResource, PackageResourceHandle>;
