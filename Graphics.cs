using _2D.Primitives;
using _2D.Shape;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _2D
{
    public class Graphics
    {
        private const float pixelWidth = 8f;
        private const float pixelHeight = 16f;

        public int Width { get; set; }
        public int Height { get; set; }

        public Vector2 CenterOfScreen { get; private set; }
        public float AspectRatio { get; private set; }

        public char[] Map { get; private set; }

        public Graphics(int width, int height)
        {
            Width = width;
            Height = height;

            CenterOfScreen = new Vector2(Width / 2, Height / 2);
            AspectRatio = width / height * pixelWidth / pixelHeight;

            Map = new char[width * height];
            for (int i = 0; i < Map.Length; i++)
                Map[i] = ' ';
        }

        public void Draw(bool isTriangulate, params IShape[] shapes)
        {
            foreach (var item in shapes)
            {
                if (isTriangulate)
                {
                    item.DrawByTriangles(this);
                    continue;
                }
                item.Draw(this);
            }
            
            Console.WriteLine(Map);
            Clear();
            Console.SetCursorPosition(0, 0);
        }

        public void DrawTriangle(Vector2 p0, Vector2 p1, Vector2 p2, char symbol, ConsoleColor color = ConsoleColor.White)
        {
            Square square = FindTriangleBoundingSquare(p0, p1, p2);

            for (float i = square.TopLeft.y; i <= square.BottomRight.y; i++)
            {
                for (float j = square.TopLeft.x; j <= square.BottomRight.x; j++)
                {
                    var current = new Vector2(j, i);
                    if (IsInTriangle(current, p0, p1, p2))
                    {
                        current = NormalizeVectorOnScreen(current);
                        var coords = GetIndex(current);
                        if (coords < Map.Length && coords > 0)
                        {
                            if (current.x > 0 && current.x < Width)
                            {
                                Console.ForegroundColor = color;
                                Map[coords] = symbol;
                            }
                        }
                       
                    }
                }
            }
        }

        public Square FindTriangleBoundingSquare(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            
            Vector2 topLeft = new Vector2(
                Math.Min(Math.Min(p0.x, p1.x), p2.x),
                Math.Min(Math.Min(p0.y, p1.y), p2.y));

            Vector2 bottomRight = new Vector2(
                Math.Max(Math.Max(p0.x, p1.x), p2.x),
                Math.Max(Math.Max(p0.y, p1.y), p2.y));

            return new Square(topLeft, bottomRight);
        }

        public void DrawLine(Vector2 startPoint, Vector2 endPoint)
        {
            startPoint = NormalizeVectorOnScreen(startPoint);
            endPoint = NormalizeVectorOnScreen(endPoint);

            int deltaX = (int)Math.Abs(endPoint.x - startPoint.x);
            int deltaY = (int)Math.Abs(endPoint.y - startPoint.y);

            int signX = (startPoint.x < endPoint.x) ? 1 : -1;
            int signY = (startPoint.y < endPoint.y) ? 1 : -1;

            int error = deltaX - deltaY;

            if (startPoint.x > Width && signX > 0)
                return;
            if (startPoint.x < 0 && signX < 0)
                return;

            int coor;

            while (startPoint.x != endPoint.x || startPoint.y != endPoint.y)
            {
                coor = GetIndex(startPoint);

                if (coor < Map.Length && coor > 0)
                {
                    if (startPoint.x > 0 && startPoint.x < Width)
                        Map[coor] = '*';
                }

                int error2 = error * 2;

                if (error2 > -deltaY)
                {
                    error -= deltaY;
                    startPoint = startPoint + new Vector2(signX, 0);
                }

                if (error2 < deltaX)
                {
                    error += deltaX;
                    startPoint = startPoint + new Vector2(0, signY);
                }
            }
        }

        public Vector2 NormalizeVectorOnScreen(Vector2 vector)
        {
            return NormalizeVectorsOnScreen(vector)[0];
        }

        public int GetIndex(Vector2 vector)
        {
            return (int)(vector.x + vector.y * Width);
        }

        private void Clear()
        {
            for (int i = 0; i < Map.Length; i++)
                Map[i] = ' ';
        }

        private Vector2[] NormalizeVectorsOnScreen(params Vector2[] vectors)
        {
            return vectors.Select(vector =>
            {
                vector *= new Vector2(1, -1);
                return new Vector2((int)vector.x * AspectRatio, (int)vector.y) + CenterOfScreen;

            }).ToArray();
        }

        private bool IsInTriangle(Vector2 p, Vector2 a, Vector2 b, Vector2 c)
        {
            var aSide = (a.y-b.y) * p.x + (b.x-a.x) * p.y + (a.x*b.y - b.x*a.y);
            var bSide = (b.y-c.y) * p.x + (c.x-b.x) * p.y + (b.x*c.y - c.x*b.y);
            var cSide = (c.y-a.y) * p.x + (a.x-c.x) * p.y + (c.x*a.y - a.x*c.y);

            return (aSide>=0 && bSide>=0 && cSide>=0) || (aSide<0 && bSide <0 && cSide <0);
        }

    }
}
