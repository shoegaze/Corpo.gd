namespace Engine.Services.Resources;


public interface IRepositoryHandle {
  IRepositoryHandle Handle { get; }


  IRepositoryHandle? Validate(string handle);
}
