
namespace _2D
{
    public struct Quatarnion
    {
        public Quatarnion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float x { get; }
        public float y { get; }
        public float z { get; }
        public float w { get; }
    }
}
