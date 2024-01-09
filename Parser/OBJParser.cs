using System.Text;
using _2D.Shape;

namespace _2D.Parser
{
    public class OBJParser : IShapeParser
    {
        public bool Export(string path, ImportedShape shape)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var vertices = shape.Mesh.Vertices;
            var edges = shape.Mesh.Edges;

            var verticesCount = shape.Mesh.Vertices.Length;
            var edgesCount = shape.Mesh.Edges.Length;

            int i = 0, j = 0;

            while (verticesCount > 0 || edgesCount > 0)
            {
                string line = string.Empty;
                if (verticesCount > 0)
                {
                    var vertex = vertices[i];
                    line = ParseVector3ToString(vertex);
                    stringBuilder.AppendLine(line);
                    i++;
                    verticesCount--;
                    continue;
                }

                if (verticesCount == 0)
                {
                    line = ParseEdgesToString(edges[j]);
                    stringBuilder.AppendLine(line);
                    j++;
                    edgesCount--;
                }
            }

            File.WriteAllText(path, stringBuilder.ToString());

            return true;

            string ParseVector3ToString(Vector3 vector)
            {
                return "v  " + vector.ToString().Replace(',', '.');
            }

            string ParseEdgesToString(Edge[] edges)
            {
                return "f " + string.Join(" ", edges.Select(x => (x.StartPoint + 1).ToString() + "/0/0"));
            }
        }

        public IShape Import(string path)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<Edge[]> edges = new List<Edge[]>();

            using (StreamReader stream = new StreamReader(path))
            {
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var splitedLine = line.Split(' ');

                    if (splitedLine[0] == "v")
                    {
                        Vector3 parsedVertex = ParseLineToVector3(line);
                        vertices.Add(parsedVertex);
                    }
                    if (splitedLine[0] == "f")
                    {
                        var parsedSurfaces = ParseSurfacesToEdges(line);
                        edges.Add(parsedSurfaces);
                    }
                }
            };

            Mesh mesh = new Mesh();
            mesh.SetEdges(edges.ToArray());
            mesh.SetVertices(vertices.ToArray());

            return new ImportedShape("imported", mesh);

            Vector3 ParseLineToVector3(string line)
            {
                var coords = line.Substring(1).Trim().Replace('.', ',').Split(' ');

                return new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
            }

            Edge[] ParseSurfacesToEdges(string line)
            {
                var surfaces = line.Substring(1).Trim().Split(' ');
                List<Edge> edges = new List<Edge>();

                for (int i = 0; i < surfaces.Length - 1; i++)
                {
                    var surface = surfaces[i].Split('/');
                    var surface1 = surfaces[i + 1].Split('/');
                    edges.Add(new Edge(int.Parse(surface[0]) - 1, int.Parse(surface1[0]) - 1));
                }

                edges.Add(new Edge(
                    int.Parse(surfaces.Last().Split('/')[0]) - 1, 
                    int.Parse(surfaces[0].Split('/')[0]) - 1));

                return edges.ToArray();
            }
        }
    }
}
