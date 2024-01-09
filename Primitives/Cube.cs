using _2D.Shape;

namespace _2D.Primitives
{
    public class Cube : BaseShape
    {
        public Cube(Mesh mesh) : base()
        {
            SetMesh(mesh);
        }

        public Cube() : base()
        {
            var vertices = new Vector3[]
            {
                new Vector3(-2, 2, 2),
                new Vector3(-2, 2, -2),
                new Vector3(2, 2, -2),
                new Vector3(2, 2, 2),
                new Vector3(-2, -2, 2),
                new Vector3(-2, -2, -2),
                new Vector3(2, -2, -2),
                new Vector3(2, -2, 2),
            };
            var edges = new Edge[][]
            {
                new Edge[]
                {
                    new Edge(0, 1),
                    new Edge(1, 2),
                    new Edge(2, 3),
                    new Edge(3, 0),
                },
                new Edge[]
                {
                    new Edge(0, 4),
                    new Edge(4, 5),
                    new Edge(5, 1),
                    new Edge(1, 0),
                },
                new Edge[]
                {
                    new Edge(3, 2),
                    new Edge(2, 6),
                    new Edge(6, 7),
                    new Edge(7, 3),
                },
                new Edge[]
                {
                    new Edge(4, 5),
                    new Edge(5, 6),
                    new Edge(6, 7),
                    new Edge(7, 4)
                },
            };

            Mesh.SetVertices(vertices);
            Mesh.SetEdges(edges);
        }
    }
}
