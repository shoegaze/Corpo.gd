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

using System;


namespace Corpo.Base.Environments.Models;


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

  public static string GetEnvironmentModeAsName() {
    EnvironmentMode mode = GetEnvironmentMode();

    return mode switch {
      EnvironmentMode.Development => "dev",
      EnvironmentMode.Staging => "stg",
      EnvironmentMode.Production => "prod",
      _ => throw new ArgumentOutOfRangeException(
        nameof(mode),
        $"Invalid environment mode: {mode}")
    };
  }
}
