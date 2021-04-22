using System;

namespace VoxelEngine.Spatial {
  class Matrix {
    private readonly Vector[] values;

    public Matrix(Vector[] values) => this.values = values;

    public static Matrix Zero(int x, int y) {
      Vector[] values = new Vector[y];
      for (int i = 0; i < y; i++) {
        values[i] = Vector.Zero(x);
      }
      return new(values);
    }

    public double this[int x, int y] {
      get => this.values[y][x];
      set => this.values[y][x] = value;
    }

    public Vector this[int y] {
      get => this.values[y];
      set => this.values[y] = value;
    }

    public static Matrix M3RotateX(double angle) {
      Matrix rotationMatrix = Matrix.Zero(3, 3);
      rotationMatrix[0, 0] = 1;
      rotationMatrix[1, 1] = Math.Cos(angle);
      rotationMatrix[1, 2] = -Math.Sin(angle);
      rotationMatrix[2, 1] = Math.Sin(angle);
      rotationMatrix[2, 2] = Math.Cos(angle);
      return rotationMatrix;
    }
    public static Matrix M3RotateY(double angle) {
      Matrix rotationMatrix = Matrix.Zero(3, 3);
      rotationMatrix[0, 0] = Math.Cos(angle);
      rotationMatrix[0, 2] = Math.Sin(angle);
      rotationMatrix[1, 1] = 1;
      rotationMatrix[2, 0] = -Math.Sin(angle);
      rotationMatrix[2, 2] = Math.Cos(angle);
      return rotationMatrix;
    }

    public static Matrix M3RotateZ(double angle) {
      Matrix rotationMatrix = Matrix.Zero(3, 3);
      rotationMatrix[0, 0] = Math.Cos(angle);
      rotationMatrix[0, 1] = -Math.Sin(angle);
      rotationMatrix[1, 0] = Math.Sin(angle);
      rotationMatrix[1, 1] = Math.Cos(angle);
      rotationMatrix[2, 2] = 1;
      return rotationMatrix;
    }


  }
}
