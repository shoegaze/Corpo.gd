using Corpo.Battle.Resources.Models;

using TeamSports.Repositories;


namespace Corpo.Battle.Resources;


public interface IBattleResourceRepository
  : IRepository<IBattleResourceRepository, BattleResourceHandle>;
