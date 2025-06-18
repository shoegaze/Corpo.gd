using Corpo.Base.Resources.Shared.Models;

using Engine.Repositories;


namespace Corpo.Base.Resources.Shared;


public interface ISharedResourceRepository
    : IRepository<ISharedResource, SharedResourceHandle>;
