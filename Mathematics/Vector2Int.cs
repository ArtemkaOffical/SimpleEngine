
namespace _2D
{
    public struct Vector2Int
    {
        public int x { get; }
        public int y { get; }

        public Vector2Int()
        {
            this.x = 0;
            this.y = 0;
        }

        public Vector2Int(int x, int y)
        {
            this.y = y;
            this.x = x;
        }

        public double Length => Math.Sqrt(x * x + y * y);

        public override string ToString()
        {
            return $"[{x} {y}]";
        }

        public Vector2Int Normalize()
        {
            return new Vector2Int((int)(x / Length), (int)(y / Length));
        }

        public static Vector2Int operator +(Vector2Int one, Vector2Int two)
        {
            return new Vector2Int(one.x + two.x, one.y + two.y);
        }

        public static Vector2Int operator -(Vector2Int one, Vector2Int two)
        {
            return new Vector2Int(one.x - two.x, one.y - two.y);
        }

        public static Vector2Int operator *(Vector2Int one, Vector2Int two)
        {
            return new Vector2Int(one.x * two.x, one.y * two.y);
        }

        public static Vector2Int operator *(Vector2Int one, float num)
        {
            return new Vector2Int((int)(one.x * num), (int)(one.y * num));
        }
    }
}
