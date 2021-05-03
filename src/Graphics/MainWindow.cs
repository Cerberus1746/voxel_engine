using System.Numerics;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;

namespace VoxelEngine.Graphics
{
  public class MainWindow
  {
    readonly Sdl2Window window;

    public MainWindow(int x, int y, int windowWidth, int windowHeight, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(x, y, windowWidth, windowHeight, windowTitle);
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public MainWindow(int windowWidth, int windowHeight, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(windowWidth, windowHeight, windowTitle);
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }
    public MainWindow(Vector2 position, Vector2 size, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(
        (int) position.X,
        (int) position.Y,
        (int) size.X,
        (int) size.Y,
        windowTitle
      );
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }
    public MainWindow(Vector2 size, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo((int) size.X, (int) size.Y, windowTitle);
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public static WindowCreateInfo GenerateInfo(
      int x,
      int y,
      int windowWidth,
      int windowHeight,
      string windowTitle
    ) => new() {
      X = x,
      Y = y,
      WindowWidth = windowWidth,
      WindowHeight = windowHeight,
      WindowTitle = windowTitle
    };

    public static WindowCreateInfo GenerateInfo(int windowWidth, int windowHeight, string windowTitle) => new() {
      WindowWidth = windowWidth,
      WindowHeight = windowHeight,
      WindowTitle = windowTitle
    };

    public void Run() {
      while(this.window.Exists) {
        this.window.PumpEvents();
      }
    }
  }
}
