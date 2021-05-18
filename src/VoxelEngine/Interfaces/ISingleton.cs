using System;

namespace VoxelEngine {
  public interface ISingleton {
    private static ISingleton instance;

    public static ISingleton Instance {get;}
  }
}
