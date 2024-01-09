using _2D.Shape;

namespace _2D.Primitives
{
    public class Square : BaseShape
    {
        public Vector2 TopLeft { get; private set; }
        public Vector2 BottomRight { get; private set; }

        public Square(Vector2 topLeft, Vector2 bottomRight) : base() 
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public override void Draw(Graphics graphics)
        {
            var delta = BottomRight - TopLeft;

            var leftBottom = new Vector2(BottomRight.x - delta.x, BottomRight.y);
            var rightUp = new Vector2(BottomRight.x, BottomRight.y - delta.y);

            graphics.DrawLine(TopLeft, leftBottom);
            graphics.DrawLine(leftBottom, BottomRight);
            graphics.DrawLine(BottomRight, rightUp);
            graphics.DrawLine(rightUp, TopLeft);
        }
    }
}
