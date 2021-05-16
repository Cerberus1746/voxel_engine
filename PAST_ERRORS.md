# Description of this file
This file contains errors or other bugs found during the development that might cause issues later on. The exact line numeration might change, so the files are marked with 

```csharp
#region PAST_BUGS.{item number}
```

For example:

```csharp
#region PAST_BUGS.1
this.keyboardInput.Update(ref this.currentInputEvents);
this.mouseInput.Update(ref this.currentInputEvents);
#endregion
```

Indicates that this snippet of code had a past error described in the first item of this file,
this file should also contain, in each item the namespace, class and method the bug was in.

Now, onto the bug list:

# Past Bugs
1. **VoxelEngine.Graphics.MainWindow.Run** <a name="bug1"></a>

   **Issue**: *Error*: `InputSnapshot` is reportedly in `Veldrid.Sdl2` but no references to it is found.

   **Cause**: This error happened when `VoxelEngine.InputHandling` was using, by mistake, version `1.0.0`.

   **Fix**: Make sure the nuget package `Veldrid.SDL2` referenced in the projects `VoxelEngine.InputHandling` and `VoxelEngine.Graphics` are the latest or at least, the same version.

   **Note**: `InputSnapshot` is in `Veldrid` namespace, not `Veldrid.Sdl2` in the latest versions, at least in version `4.8.0` which is the version currently being used as the time of writing.
