using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using VoxelEngine.Spatial;

namespace Tests.VoxelEngine.Spatial
{
  [TestClass]
  public class MatrixTests
  {
    [TestMethod]
    public void QuaternionRotation() {
      Matrix4x4 testMatrix;
      Quaternion testRot;
      Vector3 rotVector;

      rotVector = new(1, 1, 0);
      testRot = new(rotVector, 0);
      testMatrix = Matrix4x4.CreateFromQuaternion(testRot);
      Assert.AreEqual(testRot, testMatrix.GetQuaternion());

      rotVector = new(0.5f, 0.5f, -0.5f);
      testRot = new(rotVector, 0);
      testMatrix = Matrix4x4.CreateFromQuaternion(testRot);
      Assert.AreEqual(testRot, testMatrix.GetQuaternion());
    }
  }
}
