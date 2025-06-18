using Corpo.Battle.Resources.Battle.Models;

using Engine.Repositories;


namespace Corpo.Battle.Resources.Battle;


public interface IBattleResourceRepository
    : IRepository<IBattleResourceRepository, BattleResourceHandle>;
