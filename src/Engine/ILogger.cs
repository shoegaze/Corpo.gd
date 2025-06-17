// ReSharper disable UnusedMember.Global

namespace Engine;


public interface ILogger {
  void Debug(string message);
  void Info(string message);
  void Warn(string message);

  // TODO: Add `Exception exception` parameter
  void Error(string message);

  // TODO: Add `Exception exception` parameter
  void Fatal(string message);
}
