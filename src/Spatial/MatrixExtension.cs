using System;
using System.Numerics;

namespace VoxelEngine.Spatial {
    public static class MatrixExtension {
    /* Tested performance between doing the math directly and Quaternion.CreateFromRotationMatrix
    They have the exact same speed https://dotnetfiddle.net/eHQqID
    So using the builting method call for clarity */
    public static Quaternion GetQuaternionRotation(this Matrix4x4 matrix) => Quaternion.CreateFromRotationMatrix(matrix);
  }
}
