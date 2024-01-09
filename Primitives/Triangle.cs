using _2D.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D.Primitives
{
    internal class Triangle : BaseShape
    {
        public Vector2[] Vertices { get; private set; }

        public Triangle(Vector2[] vertices) : base()
        {
            Vertices = vertices;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(Vertices[0], Vertices[1]);
            graphics.DrawLine(Vertices[1], Vertices[2]);
            graphics.DrawLine(Vertices[2], Vertices[0]);
        }

    }
}
