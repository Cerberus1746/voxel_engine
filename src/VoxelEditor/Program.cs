using System;
using VoxelEngine.Graphics;

namespace VoxelEditor {
  class Program {
    static MainWindow mainWindow;

    static void Main() {
      mainWindow = new MainWindow(800, 600, "Voxel Editor");
      mainWindow.Run();
    }
  }
}
