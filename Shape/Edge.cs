
namespace _2D.Shape
{
    public class Edge
    {
        public int StartPoint { get; }
        public int EndPoint { get; }

        public Edge(int startPoint, int endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public override string ToString()
        {
            return $"{StartPoint} {EndPoint}";
        }

    }
}
