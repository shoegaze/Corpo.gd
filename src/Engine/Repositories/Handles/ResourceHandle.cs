namespace Engine.Repositories;


public abstract class ResourceHandle<TValidator> : IResourceHandle
where TValidator : IResourceHandleValidator, new() {
  private readonly static TValidator Validator = new();

  protected ResourceHandle(string handle) {
    bool isValidHandle = Validator.IsValid(handle);

    if (!isValidHandle) {
      throw new ArgumentException("Invalid handle");
    }

    Value = handle;
  }


  public string Value { get; }


  // public static bool IsValidHandle(string handle) {
  //   return Validator.IsValid(handle);
  // }
}
