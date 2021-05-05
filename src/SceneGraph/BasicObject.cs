using System;
using System.Numerics;
using VoxelEngine.Spatial;

namespace VoxelEngine.SceneGraph
{
  public abstract class BasicObject : IEquatable<BasicObject>
  {
    public Matrix4x4 matrixWorld;
    public Matrix4x4 appliedForce;
    public float mass;

    /// <summary>
    /// The Scene the object is in
    /// </summary>
    public readonly Scene scene;
    public Matrix4x4 matrixLocal;
    public Vector3 velocity;

    public Vector3 Position {
      get => this.matrixWorld.Translation;
      set => this.matrixWorld.Translation = value;
    }

    public Quaternion Rotation {
      get => this.matrixWorld.GetQuaternionRotation();
      set => this.matrixWorld *= Matrix4x4.CreateFromQuaternion(value);
    }

    public BasicObject Parent {
      get => default;
      set {
      }
    }

    /// <summary>Apply the force using the supplied time.</summary>
    /// <returns>The current velocity</returns>
    public Vector3 ApplyForce(Vector3 force, float deltaT) {
      throw new NotImplementedException();
    }

    /// <summary>Apply the force using the time from the last physics frame.</summary>
    /// <returns>The current velocity</returns>
    public Vector3 ApplyForce(Vector3 force) {
      throw new NotImplementedException();
    }

    public abstract void GraphicsFrame(float deltaT);

    public abstract void PhysicsFrame(float deltaT);

    public bool Equals(BasicObject other) => throw new NotImplementedException();
  }
}
