using System;

namespace GeometricMath
{
    class Vector
    {
        public double[] values;
        public int Length => this.values.Length;

        public Vector(int size) => this.values = new double[size];

        public double Dot(Vector otherVector)
        {
            double finalDot = 0;

            for (int curIndex = 0; curIndex < this.Length; curIndex++)
            {
                finalDot += this.values[curIndex] * otherVector.values[curIndex];
            }
            return finalDot;
        }

        public double Magnitude => Math.Sqrt(this.Dot(this));

        get normalized(): VectorND {
            let lastMagnitude = this.magnitude;
                let newArray = [];

            for (let curValue of this) {
              let curDivision = curValue / lastMagnitude;

              if (!curDivision) {
                curDivision = 0;
              }

            newArray.push(curDivision);
            }

        return this.of(...newArray);
       }
    }
}
