using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace VoxelEngine.Graphics {
  public class MainWindow {
    public GraphicsDevice graphicsDevice;
    Sdl2Window window;

    public MainWindow(string name, int posX, int posY, int sizeX, int sizeY) {
      WindowCreateInfo windowCI = new WindowCreateInfo() {
        X = posX,
        Y = posY,
        WindowWidth = sizeX,
        WindowHeight = sizeY,
        WindowTitle = name
      };

      window = VeldridStartup.CreateWindow(ref windowCI);

      GraphicsDeviceOptions options = new GraphicsDeviceOptions {
        PreferStandardClipSpaceYDirection = true,
        PreferDepthRangeZeroToOne = true
      };

      graphicsDevice = VeldridStartup.CreateGraphicsDevice(window, options);
    }

    public void Run() {
      while (window.Exists) {
        window.PumpEvents();
      }
    }
  }
}
