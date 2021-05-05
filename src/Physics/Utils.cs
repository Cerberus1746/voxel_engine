using System.Numerics;

namespace VoxelEngine.Physics
{
  public static class Utils
  {
    public static Vector3 AccelerationFromDeltas(
      Vector3 oldPos, Vector3 nextPos, float oldTime, float nextTime
    ) => (oldPos - nextPos) / (oldTime - nextTime);

    public static Vector3 AccelerationFromDeltas(
      Vector3 oldPos, Vector3 nextPos, float deltaTime
    ) => (oldPos - nextPos) / deltaTime;

    public static Vector3 AccelerationFromDeltas(
      Vector3 deltaPos, float oldTime, float nextTime
    ) => deltaPos / (oldTime - nextTime);

    public static Vector3 AccelerationFromDeltas(
      Vector3 deltaPos, float deltaTime
    ) => deltaPos / deltaTime;

    public static Vector3 AccelerationFromForce(Vector3 force, float mass) => force / mass;

    public static Vector3 AccelerationFromForce(
      Vector3 force, float mass, float deltaTime
    ) => AccelerationFromForce(force, mass) / deltaTime;

    public static Vector3 AccelerationFromForce(
      Vector3 force, float mass, float timeBefore, float timeAfter
    ) => AccelerationFromForce(force, mass) / (timeBefore - timeAfter);

    public static Vector3 ForceFromAcceleration(
      Vector3 acceleration, float mass
     ) => acceleration * mass;
  }
}
