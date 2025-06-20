namespace Corpo.Base.Environments.Models;


public static class Environment {
  public enum EnvironmentMode {
	Development,
	Staging,
	Production
  }

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
