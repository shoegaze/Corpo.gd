using TeamSports.Repositories.Handles;


namespace Corpo.Base.Resources.Shared.Models;


public class SharedResourceHandle(
  string handle
) : ResourceHandle<SharedResourceHandleValidator>(handle);
