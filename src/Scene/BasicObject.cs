using System;
using System.Numerics;
using VoxelEngine.Spatial;

namespace VoxelEngine.Scene
{
  public class BasicObject
  {
    public Matrix4x4 matrixWorld;
    public Matrix4x4 appliedForce;
    public float mass;

    public Vector3 Position {
      get => matrixWorld.Translation;
      set => matrixWorld.Translation = value;
    }

    public Quaternion Rotation {
      get => matrixWorld.GetQuaternionRotation();
      set => matrixWorld *= Matrix4x4.CreateFromQuaternion(value);
    }

    public void ApplyForce(Vector3 force, float time) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Apply the force using the time from the last physics frame
    /// </summary>
    public void ApplyForce(Vector3 force) {
      throw new NotImplementedException();
    }

    public void ApplyForce(Vector3 force, float time, out Vector3 resultingPos) {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Apply the force using the time from the last physics frame
    /// </summary>
    public void ApplyForce(Vector3 force, out Vector3 resultingPos) {
      throw new NotImplementedException();
    }

    public void AddVelocity(Vector3 velocity, float time) {
      throw new NotImplementedException();
    }

    public void GraphicsFrame() {
      throw new NotImplementedException();
    }

    public void PhysicsFrame() {
      throw new NotImplementedException();
    }
  }
}
