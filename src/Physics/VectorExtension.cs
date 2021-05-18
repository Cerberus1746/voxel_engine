using System.Numerics;

namespace VoxelEngine.Physics
{
  public static class VectorExtension
  {
    public static Vector3 ApplyAccelerationFromForce(
      this Vector3 vector,
      Vector3 force,
      float mass
    ) => vector + Utils.AccelerationFromForce(force, mass);

    public static Vector3 ApplyAccelerationFromForce(
      this Vector3 vector,
      Vector3 force,
      float mass,
      float deltaTime
    ) => vector.ApplyAccelerationFromForce(force, mass) * deltaTime;
  }
}
