#if DEBUG
  #define ENV_DEV
  #undef ENV_STG
  #undef ENV_PROD

#elif STAGING
  #define ENV_STG
  #undef ENV_DEV
  #undef ENV_PROD

#elif RELEASE
  #define ENV_PROD
  #undef ENV_DEV
  #undef ENV_STG
#endif


namespace Corpo.Services.Environment.Models;

public static class Environment {
  public enum EnvironmentMode {
    Development,
    Staging,
    Production
  }

  public static EnvironmentMode GetEnvironmentMode() {
#if ENV_DEV
      return EnvironmentMode.Development;
#elif ENV_STAGING 
      return EnvironmentMode.Staging;
#elif ENV_PROD
      return EnvironmentMode.Production;
#endif
  }
}
