using Corpo._Core.Environments.Models;


namespace Corpo._Core.Environments.Helpers;


public static class EnvironmentHelper {
  public static EnvironmentMode GetEnvironmentMode() {
#if DEVELOPMENT
    return EnvironmentMode.Development;
#elif STAGING
    return EnvironmentMode.Staging;
#elif PRODUCTION
	  return EnvironmentMode.Production;
#endif
  }

  public static string GetEnvironmentModeAsName() {
#if DEVELOPMENT
    return "dev";
#elif STAGING
    return "stg";
#elif PRODUCTION
	  return "prod";
#endif
  }
}
