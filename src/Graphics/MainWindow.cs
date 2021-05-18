using System.Diagnostics;
using System.Numerics;

using Veldrid;
using Veldrid.Sdl2;
using Veldrid.StartupUtilities;
using VoxelEngine.InputHandling;

namespace VoxelEngine.Graphics {
  public class MainWindow {
    private InputSnapshot currentInputEvents;

    #region INPUT_VARS
    private readonly MouseInput mouseInput;
    private readonly KeyboardInput keyboardInput;
    #endregion

    private readonly Stopwatch graphicFrameTime = new();

    private readonly WindowCreateInfo generatedWindowConfig;
    private readonly Sdl2Window window;

    public MainWindow(Vector2 position, Vector2 size, string windowTitle) {
      this.keyboardInput = new();
      this.mouseInput = new();

      this.generatedWindowConfig = new() {
        X = (int)position.X,
        Y = (int)position.Y,
        WindowWidth = (int)size.X,
        WindowHeight = (int)size.Y,
        WindowTitle = windowTitle
      };

      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    /// Get time from the last frame in milliseconds
    public long TimeFromLastFrame => this.graphicFrameTime.ElapsedMilliseconds;

    /// <summary>Executes the window with an infinite loop</summary>
    /// <remarks>
    /// See the file PAST_ERRORS.md section 1 if you have issues in region "PAST_BUGS.1"
    /// <seealso cref="https://github.com/Cerberus1746/voxel_engine/blob/master/PAST_ERRORS.md#bug1"/>
    /// </remarks>
    public void Run() {
      while (this.window.Exists) {
        this.graphicFrameTime.Start();

        this.currentInputEvents = this.window.PumpEvents();

        #region PAST_BUGS.1
        this.keyboardInput.Update(ref this.currentInputEvents);
        this.mouseInput.Update(ref this.currentInputEvents);
        #endregion

        this.graphicFrameTime.Stop();
      }
    }
  }
}
