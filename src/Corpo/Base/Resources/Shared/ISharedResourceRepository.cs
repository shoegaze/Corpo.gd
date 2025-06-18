using Corpo.Base.Resources.Shared.Models;

using TeamSports.Repositories;


namespace Corpo.Base.Resources.Shared;


public interface ISharedResourceRepository
    : IRepository<ISharedResource, SharedResourceHandle>;
