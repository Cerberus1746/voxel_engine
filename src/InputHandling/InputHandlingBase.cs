using Veldrid;

namespace VoxelEngine.InputHandling
{
  public class InputHandlingBase
  {
    protected InputSnapshot windowEvents;

    public void Update(ref InputSnapshot currentWindowEvents) {
      this.windowEvents = currentWindowEvents;
    }
  }
}
