
namespace _2D
{
    public struct Vector4
    {
        public float x;
        public float y;
        public float z;
        public float v;

        public Vector4(float x, float y, float z, float v)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.v = v;
        }

        public double Length => Math.Sqrt(x * x + y * y + z * z + v*v);

        public Vector4 Normalize()
        {
            return new Vector4((float)(x / Length), (float)(y / Length), (float)(z / Length), (float)(v / Length));
        }

        public static Vector4 operator +(Vector4 one, Vector4 two)
        {
            return new Vector4(one.x + two.x, one.y + two.y, one.z + two.z, one.v + two.v);
        }

        public static Vector4 operator -(Vector4 one, Vector4 two)
        {
            return new Vector4(one.x - two.x, one.y - two.y, one.z - two.z, one.v - two.v);
        }

        public static Vector4 operator *(Vector4 one, Vector4 two)
        {
            return new Vector4(one.x * two.x, one.y * two.y, one.z * two.z, one.v * two.v);
        }

        public static Vector4 operator *(Vector4 one, float num)
        {
            return new Vector4(one.x * num, one.y * num, one.z * num, one.v *num);
        }

        public override string ToString()
        {
            return $"[{x} {y} {z} {v}]";
        }

    }
}
