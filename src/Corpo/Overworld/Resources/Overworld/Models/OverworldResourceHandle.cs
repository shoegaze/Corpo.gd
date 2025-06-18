using TeamSports.Repositories.Handles;


namespace Corpo.Overworld.Resources.Overworld.Models;


public class OverworldResourceHandle(
  string handle
) : ResourceHandle<OverworldResourceHandleValidator>(handle);
