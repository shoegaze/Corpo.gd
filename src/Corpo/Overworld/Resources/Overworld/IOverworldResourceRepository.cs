using Corpo.Overworld.Resources.Overworld.Implementations;
using Corpo.Overworld.Resources.Overworld.Models;

using TeamSports.Repositories;


namespace Corpo.Overworld.Resources.Overworld;


public interface IOverworldResourceRepository
    : IRepository<OverworldResourceRepository, OverworldResourceHandle>;
