using TeamSports.Repositories.Handles;


namespace Corpo.Core.Resources.Shared.Models;


public class SharedResourceHandle(
  string handle
) : ResourceHandle<SharedResourceHandleValidator>(handle);
