
namespace _2D.Shape
{
    public class Mesh
    {
        public Vector3[] Vertices { get; private set; }
        public Edge[][] Edges { get; private set; }
        public Polygon[] Polygons { get; private set; }

        public Mesh()
        {

        }

        public Mesh(Vector3[] vertices, Edge[][] edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public void SetVertices(Vector3[] vertices)
        {
            Vertices = vertices;
        }

        public void SetEdges(Edge[][] edges)
        {
            Edges = edges;
        }

        public void SetFaces(Polygon[] faces)
        {
            Polygons = faces;
        }
    }
}
