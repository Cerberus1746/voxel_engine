using System;
using VoxelEngine.Graphics;

namespace VoxelEditor {
  class Program {
    static MainWindow mainWindow;

    static void Main() {
      mainWindow = new MainWindow("Voxel Editor", 10, 10, 800, 600);
      mainWindow.Run();
    }
  }
}
