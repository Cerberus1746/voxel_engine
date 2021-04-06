using System;
using System.Collections.Generic;

namespace SpatialMath
{
    public class Vector
    {
        private double[] values;
        public int Length => this.values.Length;

        public Vector(double[] values) => this.values = (double[])values.Clone();

        public double X
        {
            get => this.values[0];
            set => this.values[0] = value;
        }

        public double Y
        {
            get => this.values[1];
            set => this.values[1] = value;
        }

        public double Z
        {
            get => this.values[2];
            set => this.values[2] = value;
        }

        public double W
        {
            get => this.values[3];
            set => this.values[3] = value;
        }

        public double GetX() => this.values[0];
        public double GetY() => this.values[1];
        public double GetZ() => this.values[2];
        public double GetW() => this.values[3];

        public double SetX(double x) => this.values[0] = x;
        public double SetY(double y) => this.values[1] = y;
        public double SetZ(double z) => this.values[2] = z;
        public double SetW(double w) => this.values[3] = w;

        public static Vector D1(double x) => new Vector(new double[] { x });
        public static Vector D2(double x, double y) => new Vector(new double[] { x, y });
        public static Vector D3(double x, double y, double z) => new Vector(new double[] { x, y, z });
        public static Vector D4(double x, double y, double z, double w) => new Vector(new double[] { x, y, z, w });

        public double Dot(Vector otherVector)
        {
            double finalDot = 0;

            for (int curIndex = 0; curIndex < this.Length; curIndex++)
            {
                finalDot += this.values[curIndex] * otherVector.values[curIndex];
            }
            return finalDot;
        }

        public Vector Copy() => new Vector(this.values);

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

            foreach (double curValue in this.values)
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
