using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoxelEngine.SceneGraph;
using Xunit;

namespace Tests.VoxelEngine.SceneGraph {
  public class SimpleGameObject : BasicObject {
    public override void GraphicsFrame(float deltaT) => throw new NotImplementedException();
    public override void PhysicsFrame(float deltaT) => throw new NotImplementedException();
  }

  public class BasicObjectTests {
    /// <summary>
    /// Object creation needs to behave asyncronously
    /// </summary>
    [Fact]
    public async Task BasicObjectTest() {
      List<Task> objectCreationTask = new();
      List<SimpleGameObject> gameObjList = new();

      for (int x = 0; x < 10; x++) {
        objectCreationTask.Add(Task.Run(() => {
          for (int y = 0; y < 10; y++) {
            gameObjList.Add(new SimpleGameObject());
          }
        }));
      }

      await Task.WhenAll(objectCreationTask.ToArray());

      Assert.Equal(100, gameObjList.Distinct().Count());
    }
  }
}
