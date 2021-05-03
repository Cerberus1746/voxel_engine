using System;
using System.Numerics;

namespace VoxelEngine.Physics {
  public class Utils {
    public static Vector3 GetForce(Vector3 force, float mass) => force / mass;
  }
}
