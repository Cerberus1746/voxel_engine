using System;

namespace VoxelEngine.Spatial {
  public class Matrix {
    public int LengthX {
      get => values.GetLength(0);
    }
    public int LengthY {
      get => values.GetLength(1);
    }
    private readonly double[,] values;

    public Matrix(double[,] values) => this.values = values;
    /*public Matrix(Vector[] values) {
      int curLen;

      for (int x = 0; x < values.Length; x++) {
        curLen = values.Length;

        for (int y = 0; y < curLen; y++) {

        }
      }
    }*/
    public static Matrix Zero(int x, int y) => new(new double[x, y]);
    // # Indexing START #
    // ##################
    public double this[int x, int y] {
      get => values[y, x];
      set => values[y, x] = value;
    }

    public Vector GetRow(int rowIndex) {
      double[] row = new double[LengthX];

      for (int i = 0; i < LengthY; i++) {
        row[i] = values[rowIndex, i];
      }

      return new Vector(row);
    }

    public Vector GetCol(int colIndex) {
      double[] col = new double[LengthY];

      for (int i = 0; i < LengthX; i++) {
        col[i] = values[colIndex, i];
      }

      return new Vector(col);
    }
    // # Indexing END #
    // ##################

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
