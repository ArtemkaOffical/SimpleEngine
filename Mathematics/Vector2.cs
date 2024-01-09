
namespace _2D
{
    public struct Vector2
    {
        public float x { get; }
        public float y { get; }

        public Vector2()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2(float x, float y)
        {
            this.y = y;
            this.x = x;
        }

        public double Length => Math.Sqrt(x * x + y * y);

        public override string ToString()
        {
            return $"{x} {y}";
        }

        public Vector2 Normalize()
        {
            return new Vector2((float)(x / Length), (float)(y / Length));
        }

        public static Vector2 operator +(Vector2 one, Vector2 two)
        {
            return new Vector2(one.x + two.x, one.y + two.y);
        }

        public static Vector2 operator -(Vector2 one, Vector2 two)
        {
            return new Vector2(one.x - two.x, one.y - two.y);
        }

        public static Vector2 operator *(Vector2 one, Vector2 two)
        {
            return new Vector2(one.x * two.x, one.y * two.y);
        }

        public static Vector2 operator *(Vector2 one, float num)
        {
            return new Vector2(one.x * num, one.y * num);
        }

        public static implicit operator Vector3(Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0f);
        }

        public static implicit operator Vector2(Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static implicit operator Vector2Int(Vector2 vector)
        {
            return new Vector2Int((int)vector.x, (int)vector.y);
        }
    }
}
