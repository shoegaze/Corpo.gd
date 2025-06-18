using Corpo.Loading.Core.Models;

using Engine.Services;


namespace Corpo.Base.Resources;


public interface IPackageResourcesService : IService {
  // TODO: Make async
  void LoadPackage(LoadPackageContext context);
}
