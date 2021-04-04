namespace GeometricMath
{
    class Vector1 : Vector
    {
        public Vector1(int size, double x) : base(size) => this.X = x;

        public double X
        {
            get => this.values[0];
            set => this.values[0] = value;
        }

        public double GetX() => this.X;
    }
}
