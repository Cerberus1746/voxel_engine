using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoxelEngine.Spatial;
using System;
using System.Numerics;

namespace Tests.Generics {
    [TestClass]
    public class VectorTests {
        [TestMethod]
        public void QuaternionRotation() {
            Matrix4x4 testMatrix;
            Quaternion testRot;

            testRot = new(new Vector3(1, 1, 0), 0);
            testMatrix = Matrix4x4.CreateFromQuaternion(testRot);
            Assert.AreEqual(testMatrix.GetQuaternionRotation(), testRot);

            testRot = new(new Vector3(-1, -1, -2), 0);
            testMatrix = Matrix4x4.CreateFromQuaternion(testRot);
            Assert.AreEqual(testMatrix.GetQuaternionRotation(), testRot);
        }
    }
}
