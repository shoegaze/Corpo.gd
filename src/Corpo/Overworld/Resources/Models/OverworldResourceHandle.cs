using TeamSports.Repositories.Handles;


namespace Corpo.Overworld.Resources.Models;


public class OverworldResourceHandle(
  string handle
) : ResourceHandle<OverworldResourceHandleValidator>(handle);
