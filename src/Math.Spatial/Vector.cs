using System;
using System.Collections;
using System.Collections.Generic;


namespace VoxelEngine.Spatial
{
  public class VectorIsFrozen : InvalidOperationException
  {
  }

  public class Vector : IEnumerable, IEnumerator<double>
  {
    private readonly double[] values;
    private int currIndex = -1;
    public bool frozen = false;

    public int Length => this.values.Length;
    public Vector Copy() => new(this.values);


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
    public double this[int index]
    {
      get => this.values[index];
      set
      {
        if (this.frozen)
        {
          throw new VectorIsFrozen();
        }
        this.values[index] = value;
      }
    }

    public double this[string index]
    {
      get => this[AxisToIndex(index)];
      set => this[AxisToIndex(index)] = value;
    }

    private static int AxisToIndex(string axis) {
      return axis switch
      {
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
    public double X
    {
      get => this[0];
      set => this[0] = value;
    }

    public double Y
    {
      get => this[1];
      set => this[1] = value;
    }

    public double Z
    {
      get => this[2];
      set => this[2] = value;
    }

    public double W
    {
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
    public double Current
    {
      get
      {
        try
        {
          return this.values[this.currIndex];
        }
        catch (IndexOutOfRangeException)
        {
          throw new InvalidOperationException();
        }
      }
    }

    object IEnumerator.Current
    {
      get
      {
        return this.Current;
      }
    }

    public IEnumerator GetEnumerator()
    {
      foreach (double curVar in this.values)
      {
        yield return curVar;
      }
    }

    public bool MoveNext()
    {
      this.currIndex++;
      return (this.currIndex < this.Length);
    }

    public void Reset() => this.currIndex = -1;
    public void Dispose() { }
    // Iterator Methods END
    // ######################

    public double Dot(Vector otherVector)
    {
      double finalDot = 0;

      for (int curIndex = 0; curIndex < this.Length; curIndex++)
      {
        finalDot += this.values[curIndex] * otherVector.values[curIndex];
      }
      return finalDot;
    }

    public Vector Lerp(Vector otherVector, double t)
    {
      if (t == 0)
      {
        return this.Copy();
      }
      else if (t == 1)
      {
        return otherVector.Copy();
      }

      double[] newArr = new double[this.Length];

      for (int curIndex = 0; curIndex < this.Length; curIndex++)
      {
        newArr[curIndex] = ((this.values[curIndex] + otherVector.values[curIndex]) * t);
      }

      return new Vector(newArr);
    }

    public double Magnitude() => Math.Sqrt(this.Dot(this));

    public Vector Normalized()
    {
      double lastMagnitude = this.Magnitude();
      List<double> newArray = new List<double>();

      foreach (double curValue in this)
      {
        if (curValue == 0 || lastMagnitude == 0)
        {
          newArray.Add(0);
        }
        else
        {
          newArray.Add(curValue / lastMagnitude);
        }
      }

      double[] newValues = newArray.ToArray();
      return new Vector(newValues);
    }

    public double Distance(Vector otherVector)
    {
      double totalDistance = 0;

      for (int curIndex = 0; curIndex < this.Length; curIndex++)
      {
        double curSubtraction = this.values[curIndex] - otherVector.values[curIndex];
        totalDistance += curSubtraction * curSubtraction;
      }

      return Math.Sqrt(totalDistance);
    }
  }
}
