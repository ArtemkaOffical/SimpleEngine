namespace _2D.Shape
{
    public class Polygon
    {
        public int[] Indices { get; private set; }

        public Polygon(int[] indices)
        {
            Indices = indices;
        }
    }
}