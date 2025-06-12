namespace Corpo.Engine.Services;


public enum ServiceTiming {
  Empty,
  Safe, // TODO(shoegaze): ServiceProvider.Build/Initialize essential services
  Initialized,
  Closed
}
