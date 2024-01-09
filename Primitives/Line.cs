using _2D.Shape;

namespace _2D.Primitives
{
    public class Line : BaseShape
    {
        public Vector2? StartPoint { get; private set; }
        public Vector2? EndPoint { get; private set; }

        public Line(Mesh mesh) : base()
        {
            SetMesh(mesh);
        }

        public Line() : base()
        {
            var vertices = new Vector3[]
            {
                new Vector2(1,1),
                new Vector2(7,7),
            };

            var edges = new Edge[][]
            {
                new Edge[]{new Edge(0, 1),},
            };

            Mesh.SetVertices(vertices);
            Mesh.SetEdges(edges);
        }

        public Line(Vector2 startPoint, Vector2 endPoint) : base()
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public override void Draw(Graphics graphics)
        {
            if(StartPoint != null || EndPoint != null)
            {
                graphics.DrawLine(StartPoint.Value, EndPoint.Value);
                return;
            }
            base.Draw(graphics);

        }
    }
}
