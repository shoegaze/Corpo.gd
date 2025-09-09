using Corpo.Core.Resources.Shared.Models;

using TeamSports.Repositories;


namespace Corpo.Core.Resources.Shared;


public interface ISharedResourceRepository
  : IRepository<ISharedResource, SharedResourceHandle>;
