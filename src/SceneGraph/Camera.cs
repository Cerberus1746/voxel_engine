using System;
using System.Numerics;

namespace VoxelEngine.SceneGraph {
  class Camera : BasicObject {
    public float fov = 1f;
    public float near = 1f;
    public float far = 1000f;

    public Matrix4x4 viewMatrix;
    public Matrix4x4 projectionMatrix;


    // TODO: Write methods for the camera
    public override void GraphicsFrame(float deltaT) => throw new NotImplementedException();
    public override void PhysicsFrame(float deltaT) => throw new NotImplementedException();
  }
}
