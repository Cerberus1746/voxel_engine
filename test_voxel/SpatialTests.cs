using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpatialMath;

namespace test_voxel
{
    [TestClass]
    public class SpatialTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Vector newVector = new(new double[] { 5, 7, 2, 10 });
            Assert.AreEqual(newVector.X, 5);
            Assert.AreEqual(newVector.Y, 7);
            Assert.AreEqual(newVector.Z, 2);
            Assert.AreEqual(newVector.W, 10);
        }
    }
}
