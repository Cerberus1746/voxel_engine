
namespace VoxelEngine {
  /// <summary>Interface for thread safe singleton.</summary>
  public interface IThreadSafeSingleton: ISingleton {
    private static readonly object threadLock;
  }
}
