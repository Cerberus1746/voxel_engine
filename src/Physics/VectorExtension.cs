using System.Numerics;

namespace VoxelEngine.Physics
{
  public static class VectorExtension
  {
    public static Vector3 GetAcceleration(
      this Vector3 vector,
      Vector3 force,
      float mass
    ) => vector + Utils.GetForce(force, mass);

    public static Vector3 GetAcceleration(
      this Vector3 vector,
      Vector3 force,
      float mass,
      float time
    ) => vector.GetAcceleration(force, mass) * time;
  }
}
