using Corpo.Overworld.Resources._Impl;
using Corpo.Overworld.Resources.Models;

using TeamSports.Repositories;


namespace Corpo.Resources.Overworld;


public interface IOverworldResourceRepository
  : IRepository<OverworldResourceRepository, OverworldResourceHandle>;
