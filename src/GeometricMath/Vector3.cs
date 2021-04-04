namespace GeometricMath
{
    class Vector3 : Vector2
    {
        public double Z
        {
            get { return this.values[2]; }
            set { this.values[2] = value; }
        }
    }
}
