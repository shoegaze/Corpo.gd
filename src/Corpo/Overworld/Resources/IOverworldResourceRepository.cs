using Corpo.Overworld.Resources._Impl;
using Corpo.Overworld.Resources.Models;

using TeamSports.Repositories;


namespace Corpo.Overworld.Resources;


public interface IOverworldResourceRepository
  : IRepository<OverworldResourceRepository, OverworldResourceHandle>;
