using _2D.Shape;

namespace _2D.Parser
{
    public interface IShapeParser
    {
        IShape Import(string path);
        bool Export(string path, ImportedShape shape);
    }
}
