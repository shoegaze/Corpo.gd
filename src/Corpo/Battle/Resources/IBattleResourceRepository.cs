using Corpo.Battle.Resources.Models;

using TeamSports.Repositories;


namespace Corpo.Resources.Battle;


public interface IBattleResourceRepository
  : IRepository<IBattleResourceRepository, BattleResourceHandle>;
