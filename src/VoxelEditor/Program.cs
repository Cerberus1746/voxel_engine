using System.Numerics;
using VoxelEngine.Graphics;

namespace VoxelEditor
{
  internal class Program
  {

    private static void Main() {
      Vector2 mainWindowPosition = new(20, 20);
      Vector2 mainWindowSize = new(800, 600);

      MainWindow mainWindow = new(mainWindowPosition, mainWindowSize, "Voxel Editor");
      mainWindow.Run();
    }
  }
}
