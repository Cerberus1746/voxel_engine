using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VoxelEngine.SceneGraph;

namespace Tests.VoxelEngine.SceneGraph
{
  public class SimpleGameObject : BasicObject
  {
    public override void GraphicsFrame(float deltaT) => throw new NotImplementedException();
    public override void PhysicsFrame(float deltaT) => throw new NotImplementedException();
  }

  [TestClass]
  public class BasicObjectTests
  {
    /// <summary>
    /// Object creation needs to behave asyncronously
    /// </summary>
    [TestMethod]
    public async Task BasicObjectTest() {
      List<Task> objectCreationTask = new();
      List<SimpleGameObject> gameObjList = new();

      for(int i = 0; i < 10; i++) {
        objectCreationTask.Add(Task.Run(() => {
          for(int i = 0; i < 10; i++) {
            gameObjList.Add(new SimpleGameObject());
          }
        }));
      }

      await Task.WhenAll(objectCreationTask.ToArray());

      Assert.AreEqual(0, gameObjList.Distinct().Count());
    }
  }
}
