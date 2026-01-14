using Corpo._App;

using TeamSports.Adapters.Godot.Services;
using TeamSports.Core.Game;


namespace Corpo._Core.App;


public interface ICorpoAppService : IGodotAppService<CorpoApp>, IStartable;
