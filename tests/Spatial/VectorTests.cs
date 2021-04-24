using Microsoft.VisualStudio.TestTools.UnitTesting;
using VoxelEngine.Spatial;
using System;

namespace test_voxel {
  [TestClass]
  public class VectorTests {
    [TestMethod]
    public void TestVectorCreationAndSetterGetter() {
      Vector newVector1 = Vector.D1(5);
      Vector newVector2 = Vector.D2(5, 7);
      Vector newVector3 = Vector.D3(5, 7, 2);
      Vector newVector4 = Vector.D4(5, 7, 2, 10);

      Assert.AreEqual(newVector1.GetX(), newVector1.X);
      Assert.AreEqual(newVector2.GetY(), newVector2.Y);
      Assert.AreEqual(newVector3.GetZ(), newVector3.Z);
      Assert.AreEqual(newVector4.GetW(), newVector4.W);

      newVector1.SetX(-9);
      newVector2.SetY(-3);
      newVector3.SetZ(5);
      newVector4.SetW(10);

      Assert.AreEqual(newVector1.X, -9);
      Assert.AreEqual(newVector2.Y, -3);
      Assert.AreEqual(newVector3.Z, 5);
      Assert.AreEqual(newVector4.W, 10);
    }

    [TestMethod]
    public void VectorMagnitude() {
      Vector testVector;

      testVector = Vector.D2(0, 0);
      Assert.AreEqual(testVector.Magnitude(), 0);

      testVector = Vector.D2(0, 3);
      Assert.AreEqual(testVector.Magnitude(), 3);

      testVector = Vector.D2(3, 0);
      Assert.AreEqual(testVector.Magnitude(), 3);

      testVector = Vector.D2(25, -9);
      Assert.AreEqual(Math.Round(testVector.Magnitude(), 1), 26.6);
    }

    [TestMethod]
    public void VectorNormalization() {
      Vector testVector;
      Vector normalizedVector;

      testVector = Vector.D2(0, 0);
      normalizedVector = testVector.Normalized();
      Assert.AreEqual(normalizedVector.X, 0);
      Assert.AreEqual(normalizedVector.Y, 0);

      testVector = Vector.D2(15, 0);
      normalizedVector = testVector.Normalized();
      Assert.AreEqual(normalizedVector.X, 1);
      Assert.AreEqual(normalizedVector.Y, 0);

      testVector = Vector.D2(0, 15);
      normalizedVector = testVector.Normalized();
      Assert.AreEqual(normalizedVector.X, 0);
      Assert.AreEqual(normalizedVector.Y, 1);

      testVector = Vector.D2(15, 15);
      normalizedVector = testVector.Normalized();
      Assert.AreEqual(Math.Round(normalizedVector.X, 1), 0.7);
      Assert.AreEqual(Math.Round(normalizedVector.Y, 1), 0.7);

      testVector = Vector.D3(25, -7, 10.5);
      normalizedVector = testVector.Normalized();
      Assert.AreEqual(Math.Round(normalizedVector.X, 2), 0.89);
      Assert.AreEqual(Math.Round(normalizedVector.Y, 2), -0.25);
      Assert.AreEqual(Math.Round(normalizedVector.Z, 2), 0.37);
    }

    [TestMethod]
    public void VectorRounding() {
      Vector newVector3 = Vector.D3(5.3, 7.9, 2.1);
      Vector roundedVector3 = newVector3.Round();

      Assert.AreEqual(roundedVector3.GetX(), 5);
      Assert.AreEqual(roundedVector3.GetY(), 8);
      Assert.AreEqual(roundedVector3.GetZ(), 2);
    }

    [TestMethod]
    public void VectorFlooring() {
      Vector newVector3 = Vector.D3(5.3, 7.9, 2.1);
      Vector roundedVector3 = newVector3.Floor();

      Assert.AreEqual(roundedVector3.GetX(), 5);
      Assert.AreEqual(roundedVector3.GetY(), 7);
      Assert.AreEqual(roundedVector3.GetZ(), 2);
    }

    [TestMethod]
    public void VectorCeiling() {
      Vector newVector3 = Vector.D3(5.3, 7.9, 2.1);
      Vector roundedVector3 = newVector3.Ceiling();

      Assert.AreEqual(roundedVector3.GetX(), 6);
      Assert.AreEqual(roundedVector3.GetY(), 8);
      Assert.AreEqual(roundedVector3.GetZ(), 3);
    }
  }
}
