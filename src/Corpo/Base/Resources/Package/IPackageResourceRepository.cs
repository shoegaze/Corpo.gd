using Corpo.Base.Resources.Package.Models;

using TeamSports.Repositories;


namespace Corpo.Base.Resources.Package;


public interface IPackageResourceRepository
    : IRepository<IPackageResource, PackageResourceHandle>;
