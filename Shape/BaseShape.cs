
namespace _2D.Shape
{

    public abstract class BaseShape : IShape
    {
        public Mesh Mesh { get; private set; }
        public string Name { get; private set; }

        public BaseShape()
        {
            Name = "Default";
            Mesh = new Mesh();
        }

        public BaseShape(string name)
        {
            Name = name;
            Mesh = new Mesh();
        }

        public BaseShape(string name, Mesh mesh)
        {
            Name = name;
            Mesh = mesh;
        }

        protected enum PlygonType
        {
            Triangle,
            Quad,
            Penta
        }

        protected Dictionary<int, PlygonType> PolygonTypes = new Dictionary<int, PlygonType>
        {
            [3] = PlygonType.Triangle,
            [4] = PlygonType.Quad,
            [5] = PlygonType.Penta,
        };

        public void Triangulate()
        {
            if (Mesh == null || Mesh.Edges == null)
                return;

            List<Polygon> polygonIndices = new List<Polygon>();
            Edge[][] surfaces = Mesh.Edges;
            var polySize = surfaces.Length;


            for (int i = 0; i < polySize; i++)
            {
                var polygonExist = PolygonTypes.TryGetValue(surfaces[i].Length, out PlygonType polygon);
                if (!polygonExist) return;


                switch (polygon)
                {
                    case PlygonType.Triangle:
                        int vertexIndex1;
                        int vertexIndex2;
                        int vertexIndex3;

                        vertexIndex1 = surfaces[i][0].StartPoint;
                        vertexIndex2 = surfaces[i][1].StartPoint;
                        vertexIndex3 = surfaces[i][2].StartPoint;

                        polygonIndices.Add(new Polygon(
                            new int[] { vertexIndex1, vertexIndex2, vertexIndex3 }));

                        break;

                    case PlygonType.Quad:

                        vertexIndex1 = surfaces[i][0].StartPoint;
                        vertexIndex2 = surfaces[i][1].StartPoint;
                        vertexIndex3 = surfaces[i][2].StartPoint;
                        var vertexIndex4 = surfaces[i][3].StartPoint;

                        polygonIndices.Add(new Polygon(
                            new int[] { vertexIndex1, vertexIndex2, vertexIndex3 }));

                        polygonIndices.Add(new Polygon(
                            new int[] { vertexIndex3, vertexIndex4, vertexIndex1 }));

                        break;

                    case PlygonType.Penta:

                        vertexIndex1 = surfaces[i][0].StartPoint;
                        vertexIndex2 = surfaces[i][1].StartPoint;
                        vertexIndex3 = surfaces[i][2].StartPoint;
                        vertexIndex4 = surfaces[i][3].StartPoint;
                        int vertexIndex5 = surfaces[i][4].StartPoint;

                        polygonIndices.Add(new Polygon(
                            new int[] { vertexIndex1, vertexIndex2, vertexIndex5 }));

                        polygonIndices.Add(new Polygon(
                           new int[] { vertexIndex2, vertexIndex3, vertexIndex5 }));

                        polygonIndices.Add(new Polygon(
                           new int[] { vertexIndex3, vertexIndex4, vertexIndex5 }));

                        polygonIndices.Add(new Polygon(
                          new int[] { vertexIndex1, vertexIndex2, vertexIndex4 }));

                        polygonIndices.Add(new Polygon(
                          new int[] { vertexIndex1, vertexIndex3, vertexIndex4 }));

                        polygonIndices.Add(new Polygon(
                          new int[] { vertexIndex1, vertexIndex4, vertexIndex5 }));

                        break;
                }

            }
            Mesh.SetFaces(polygonIndices.ToArray());
        }

        public void SetMesh(Mesh mesh)
        {
            Mesh = mesh;
        }

        public virtual void Draw(Graphics graphics)
        {
            var vertices = Mesh.Vertices;
            for (int i = 0; i < Mesh.Edges.Length; i++)
            {
                var edge = Mesh.Edges[i];

                for (int j = 0; j < edge.Length; j++)
                {
                    var startPoint = vertices[edge[j].StartPoint];
                    var endPoint = vertices[edge[j].EndPoint];

                    graphics.DrawLine(startPoint, endPoint);
                }

            }
        }

        public virtual void DrawByTriangles(Graphics graphics)
        {
            if (Mesh.Polygons == null)
                Triangulate();

            var faces = Mesh.Polygons;
            var vertices = Mesh.Vertices;

            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 firstPoint;
                Vector3 endPoint;

                for (int j = 0; j < faces[i].Indices.Length - 1; j++)
                {
                    firstPoint = vertices[faces[i].Indices[j]];
                    endPoint = vertices[faces[i].Indices[j + 1]];
                    graphics.DrawLine(firstPoint, endPoint);
                }

                firstPoint = vertices[faces[i].Indices.Last()];
                endPoint = vertices[faces[i].Indices[0]];
                graphics.DrawLine(firstPoint, endPoint);
            }

            for (int i = 0; i < faces.Length; i++)
            {
                var v1 = Mesh.Vertices[Mesh.Polygons[i].Indices[0]];
                var v2 = Mesh.Vertices[Mesh.Polygons[i].Indices[1]];
                var v3 = Mesh.Vertices[Mesh.Polygons[i].Indices[2]];
                graphics.DrawTriangle(v1, v2, v3, '@');
            }

        }
    }
}
