using System.Numerics;

namespace VoxelEngine.Physics
{
  public static class MatrixExtension
  {
    public static void ApplyAcceleration(
      this Matrix4x4 matrix,
      Vector3 force,
      float mass
    ) => matrix.Translation = matrix.Translation.ApplyAccelerationFromForce(force, mass);

    public static void ApplyAcceleration(
      this Matrix4x4 matrix,
      Vector3 force,
      float mass,
      float deltaTime
    ) => matrix.Translation = matrix.Translation.ApplyAccelerationFromForce(force, mass, deltaTime);
  }
}
