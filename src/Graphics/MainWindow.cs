using System;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using Veldrid;
using Veldrid.Sdl2;
using Veldrid.SPIRV;
using Veldrid.StartupUtilities;
using VoxelEngine.InputHandling;
using VoxelEngine.SceneGraph;

namespace VoxelEngine.Graphics
{
  internal struct VertexPositionColor
  {
    public const uint SizeInBytes = 24;
    public Vector2 Position;
    public RgbaFloat Color;

    public VertexPositionColor(Vector2 position, RgbaFloat color) {
      this.Position = position;
      this.Color = color;
    }
  }

  public class MainWindow : IDisposable
  {
    private GraphicsDevice graphicsDevice;
    private CommandList commandList;
    private DeviceBuffer vertexBuffer;
    private DeviceBuffer indexBuffer;
    private InputSnapshot currentInputEvents;
    private Shader[] shaders;
    private Pipeline pipeline;

    private MouseInput mouseInput;
    private KeyboardInput keyboardInput;

    private const string VertexCode = @"
#version 450
layout(location = 0) in vec2 Position;
layout(location = 1) in vec4 Color;
layout(location = 0) out vec4 fsin_Color;
void main()
{
    gl_Position = vec4(Position, 0, 1);
    fsin_Color = Color;
}";

    private const string FragmentCode = @"
#version 450
layout(location = 0) in vec4 fsin_Color;
layout(location = 0) out vec4 fsout_Color;
void main()
{
    fsout_Color = fsin_Color;
}";

    private readonly Stopwatch graphicFrameTime = new();
    private readonly Sdl2Window window;
    private Graph scenes;

    public MainWindow(int x, int y, int windowWidth, int windowHeight, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(
        x, y, windowWidth, windowHeight, windowTitle
      );
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public MainWindow(int windowWidth, int windowHeight, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(windowWidth, windowHeight, windowTitle);
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public MainWindow(Vector2 position, Vector2 size, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(
        (int) position.X, (int) position.Y, (int) size.X, (int) size.Y, windowTitle
      );
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public MainWindow(Vector2 size, string windowTitle) {
      WindowCreateInfo generatedWindowConfig = GenerateInfo(
        (int) size.X, (int) size.Y, windowTitle
      );
      this.window = VeldridStartup.CreateWindow(ref generatedWindowConfig);
    }

    public long TimeFromLastFrame => this.graphicFrameTime.ElapsedMilliseconds;

    public static WindowCreateInfo GenerateInfo(
      int x, int y, int windowWidth, int windowHeight, string windowTitle
    ) => new() {
      X = x,
      Y = y,
      WindowWidth = windowWidth,
      WindowHeight = windowHeight,
      WindowTitle = windowTitle
    };

    public static WindowCreateInfo GenerateInfo(
        int windowWidth, int windowHeight, string windowTitle
    ) => new() {
      WindowWidth = windowWidth,
      WindowHeight = windowHeight,
      WindowTitle = windowTitle
    };

    /// <summary>
    /// Executes the window with an infinite loop
    /// </summary>
    /// <remarks>See the file PAST_ERRORS.md section 1 if you have issues here. More specifically
    /// in the #region PAST_ERRORS.1</remarks>
    public void Run() {
      GraphicsDeviceOptions options = new GraphicsDeviceOptions {
        PreferStandardClipSpaceYDirection = true,
        PreferDepthRangeZeroToOne = true
      };

      this.graphicsDevice = VeldridStartup.CreateGraphicsDevice(this.window, options, GraphicsBackend.Vulkan);

      this.CreateResources();

      while(this.window.Exists) {
        this.graphicFrameTime.Start();

        this.currentInputEvents = this.window.PumpEvents();

        #region PAST_BUGS.1

        this.keyboardInput.Update(ref this.currentInputEvents);
        this.mouseInput.Update(ref this.currentInputEvents);

        #endregion

        if(this.window.Exists) {
          this.Draw();
        }

        this.graphicFrameTime.Stop();
      }
    }

    private void CreateResources() {
      this.keyboardInput = new();
      this.mouseInput = new();
      ResourceFactory factory = this.graphicsDevice.ResourceFactory;

      VertexPositionColor[] quadVertices = {
                new VertexPositionColor(new Vector2(-.75f, .75f), RgbaFloat.Red),
                new VertexPositionColor(new Vector2(.75f, .75f), RgbaFloat.Green),
                new VertexPositionColor(new Vector2(-.75f, -.75f), RgbaFloat.Blue),
                new VertexPositionColor(new Vector2(.75f, -.75f), RgbaFloat.Yellow)
            };
      BufferDescription vbDescription = new BufferDescription(
          4 * VertexPositionColor.SizeInBytes,
          BufferUsage.VertexBuffer);
      this.vertexBuffer = factory.CreateBuffer(vbDescription);
      this.graphicsDevice.UpdateBuffer(this.vertexBuffer, 0, quadVertices);

      ushort[] quadIndices = { 0, 1, 2, 3 };
      BufferDescription ibDescription = new BufferDescription(
          4 * sizeof(ushort),
          BufferUsage.IndexBuffer);
      this.indexBuffer = factory.CreateBuffer(ibDescription);
      this.graphicsDevice.UpdateBuffer(this.indexBuffer, 0, quadIndices);

      VertexLayoutDescription vertexLayout = new VertexLayoutDescription(
          new VertexElementDescription("Position", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float2),
          new VertexElementDescription("Color", VertexElementSemantic.TextureCoordinate, VertexElementFormat.Float4));

      ShaderDescription vertexShaderDesc = new ShaderDescription(
          ShaderStages.Vertex,
          Encoding.UTF8.GetBytes(VertexCode),
          "main");
      ShaderDescription fragmentShaderDesc = new ShaderDescription(
          ShaderStages.Fragment,
          Encoding.UTF8.GetBytes(FragmentCode),
          "main");

      this.shaders = factory.CreateFromSpirv(vertexShaderDesc, fragmentShaderDesc);

      // Create pipeline
      GraphicsPipelineDescription pipelineDescription = new GraphicsPipelineDescription();
      pipelineDescription.BlendState = BlendStateDescription.SingleOverrideBlend;
      pipelineDescription.DepthStencilState = new DepthStencilStateDescription(
          depthTestEnabled: true,
          depthWriteEnabled: true,
          comparisonKind: ComparisonKind.LessEqual);
      pipelineDescription.RasterizerState = new RasterizerStateDescription(
          cullMode: FaceCullMode.Back,
          fillMode: PolygonFillMode.Solid,
          frontFace: FrontFace.Clockwise,
          depthClipEnabled: true,
          scissorTestEnabled: false);
      pipelineDescription.PrimitiveTopology = PrimitiveTopology.TriangleStrip;
      pipelineDescription.ResourceLayouts = System.Array.Empty<ResourceLayout>();
      pipelineDescription.ShaderSet = new ShaderSetDescription(
          vertexLayouts: new VertexLayoutDescription[] { vertexLayout },
          shaders: this.shaders);
      pipelineDescription.Outputs = this.graphicsDevice.SwapchainFramebuffer.OutputDescription;

      this.pipeline = factory.CreateGraphicsPipeline(pipelineDescription);

      this.commandList = factory.CreateCommandList();
    }

    private void Draw() {
      // Begin() must be called before commands can be issued.
      this.commandList.Begin();

      // We want to render directly to the output window.
      this.commandList.SetFramebuffer(this.graphicsDevice.SwapchainFramebuffer);
      this.commandList.ClearColorTarget(0, RgbaFloat.Black);

      // Set all relevant state to draw our quad.
      this.commandList.SetVertexBuffer(0, this.vertexBuffer);
      this.commandList.SetIndexBuffer(this.indexBuffer, IndexFormat.UInt16);
      this.commandList.SetPipeline(this.pipeline);
      // Issue a Draw command for a single instance with 4 indices.
      this.commandList.DrawIndexed(
          indexCount: 4,
          instanceCount: 1,
          indexStart: 0,
          vertexOffset: 0,
          instanceStart: 0);

      // End() must be called before commands can be submitted for execution.
      this.commandList.End();
      this.graphicsDevice.SubmitCommands(this.commandList);

      // Once commands have been submitted, the rendered image can be presented to the application window.
      this.graphicsDevice.SwapBuffers();
    }

    public void Dispose() {
      this.pipeline.Dispose();

      foreach(Shader shader in this.shaders) {
        shader.Dispose();
      }

      this.commandList.Dispose();
      this.vertexBuffer.Dispose();
      this.indexBuffer.Dispose();
      this.graphicsDevice.Dispose();

      GC.SuppressFinalize(this);
    }
  }
}
