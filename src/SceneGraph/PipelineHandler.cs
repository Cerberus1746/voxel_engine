using System;
using System.Collections.Generic;

using Veldrid;

namespace VoxelEngine.SceneGraph {
  public class ObjectPipelineHandler : Dictionary<Type, Pipeline>, IThreadSafeSingleton {
    private static ObjectPipelineHandler instance;

    private static readonly object threadLock = new();

    public static ObjectPipelineHandler Instance {
      get {
        lock (threadLock) {
          if (instance is null) {
            instance = new ObjectPipelineHandler();
          }
        }
        return instance;
      }
    }

    private ObjectPipelineHandler() {}
  }
}
