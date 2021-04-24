using System;
using System.Collections;
using System.Collections.Generic;

namespace VoxelEngine.Spatial {
  public class VectorIsFrozen : InvalidOperationException {
  }

  public class Vector : IEnumerable, IEnumerator<double> {
    private readonly double[] values;
    private int currIndex = -1;
    public bool frozen = false;

    public int Length => values.Length;
    public Vector Copy() => new(values);

    // # Constructors START #
    // ######################
    public Vector(double[] values) => this.values = values;
    public static Vector D1(double x) => new(new double[] { x });
    public static Vector D2(double x, double y) => new(new double[] { x, y });
    public static Vector D3(double x, double y, double z) => new(new double[] { x, y, z });
    public static Vector D4(double x, double y, double z, double w) => new(new double[] { x, y, z, w });
    public static Vector Zero(int size) => new(new double[size]);
    // # Constructors END #
    // ####################

    // # Indexing START #
    // ##################
    public double this[int index] {
      get => values[index];
      set {
        if (frozen) {
          throw new VectorIsFrozen();
        }
        values[index] = value;
      }
    }

    public double this[string index] {
      get => this[AxisToIndex(index)];
      set => this[AxisToIndex(index)] = value;
    }

    private static int AxisToIndex(string axis) {
      return axis switch {
        "x" or "X" => 0,
        "y" or "Y" => 1,
        "z" or "Z" => 2,
        "w" or "W" => 3,
        _ => throw new KeyNotFoundException(),
      };
    }
    // # Indexing END #
    // ################

    // # Axis properties START #
    // #########################
    public double X {
      get => this[0];
      set => this[0] = value;
    }

    public double Y {
      get => this[1];
      set => this[1] = value;
    }

    public double Z {
      get => this[2];
      set => this[2] = value;
    }

    public double W {
      get => this[3];
      set => this[3] = value;
    }
    // # Axis properties END #
    // #######################

    // # Axis methods START #
    // ######################
    public double SetX(double x) => this[0] = x;
    public double SetY(double y) => this[1] = y;
    public double SetZ(double z) => this[2] = z;
    public double SetW(double w) => this[3] = w;

    public double GetX() => this[0];
    public double GetY() => this[1];
    public double GetZ() => this[2];
    public double GetW() => this[3];
    // # Axis methods END #
    // ####################

    // # Iterator Methods START #
    // ##########################
    public double Current {
      get {
        try {
          return values[currIndex];
        }
        catch (IndexOutOfRangeException) {
          throw new InvalidOperationException();
        }
      }
    }

    object IEnumerator.Current {
      get {
        return Current;
      }
    }

    public IEnumerator GetEnumerator() {
      foreach (double curVar in values) {
        yield return curVar;
      }
    }

    public bool MoveNext() {
      currIndex++;
      return (currIndex < Length);
    }

    public void Reset() => currIndex = -1;
    public void Dispose() { }

    public Vector ForEach(Func<double, double> func) {
      int currLen = Length;
      double[] newArray = new double[currLen];

      for (int i = 0; i < currLen; i++) {
        newArray[i] = func(this[i]);
      }

      return new Vector(newArray);
    }
    // Iterator Methods END
    // ######################

    public double Dot(Vector otherVector) {
      double finalDot = 0;

      for (int curIndex = 0; curIndex < Length; curIndex++) {
        finalDot += values[curIndex] * otherVector.values[curIndex];
      }
      return finalDot;
    }

    public Vector Lerp(Vector otherVector, double t) {
      if (t == 0) {
        return Copy();
      }
      else if (t == 1) {
        return otherVector.Copy();
      }

      int curLen = Length;
      double[] newArr = new double[curLen];

      for (int curIndex = 0; curIndex < curLen; curIndex++) {
        newArr[curIndex] = (values[curIndex] + otherVector.values[curIndex]) * t;
      }

      return new Vector(newArr);
    }

    public double Magnitude() => Math.Sqrt(Dot(this));

    public Vector Normalized(){
      return ForEach((double curValue) => (curValue == 0) ? 0 : (curValue / Magnitude()));
    }

    public double Distance(Vector otherVector) {
      double totalDistance = 0;

      for (int curIndex = 0; curIndex < Length; curIndex++) {
        double curSubtraction = values[curIndex] - otherVector.values[curIndex];
        totalDistance += curSubtraction * curSubtraction;
      }

      return Math.Sqrt(totalDistance);
    }

    public Vector Round(int digits) {
      int currLen = Length;

      double[] newArray = new double[currLen];

      for (int i = 0; i < currLen; i++) {
        if (digits == -1) {
          newArray[i] = Math.Round(this[i]);
        }
        else {
          newArray[i] = Math.Round(this[i], digits);
        }
      }

      return new Vector(newArray);
    }

    public Vector Round() => Round(-1);

    public Vector Floor() => ForEach(Math.Floor);
    public Vector Ceiling() => ForEach(Math.Ceiling);

  }
}
