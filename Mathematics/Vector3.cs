namespace _2D
{
    public struct Vector3
    {
        public float x { get; }
        public float y { get; }
        public float z { get; }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public double Length => Math.Sqrt(x * x + y * y + z * z);

        public Vector3 Normalize()
        { 
            return new Vector3((float)(x / Length), (float)(y / Length), (float)(z / Length));
        }

        public static Vector3 operator +(Vector3 one, Vector3 two)
        {
            return new Vector3(one.x + two.x, one.y + two.y, one.z + two.z);
        }

        public static Vector2 operator -(Vector3 one, Vector3 two)
        {
            return new Vector3(one.x - two.x, one.y - two.y, one.z - two.z);
        }

        public static Vector3 operator *(Vector3 one, Vector3 two)
        {
            return new Vector3(one.x * two.x, one.y * two.y, one.z * two.z);
        }

        public static Vector3 operator *(Vector3 one, float num)
        {
            return new Vector3(one.x * num, one.y * num, one.z * num);
        }

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }
}