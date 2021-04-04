namespace GeometricMath
{
    class Vector2 : Vector1
    {
        public double Y
        {
            get => this.values[1];
            set => this.values[1] = value;
        }
    }
}
