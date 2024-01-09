using _2D.Parser;
using _2D.Shape;
using System.Windows.Forms;

namespace _2D
{
    public class Engine
    {
        public Graphics Graphics { get; private set; }
        public KeyController Controller { get; private set; }
        public IShape Shape { get; private set; }

        public Engine(string modelPath)
        {
            Graphics = new Graphics(Console.WindowWidth,Console.WindowHeight);
            Controller = new KeyController();
            Controller.OnKeyPress += Pressed;
            Shape = new OBJParser().Import(modelPath);
        }

        public void Start()
        {
            Thread drawing = new Thread(new ThreadStart(Draw));
            Thread updating = new Thread(new ThreadStart(Update));

            Thread thread = new Thread(new ThreadStart(Controller.Pressed));
            thread.SetApartmentState(ApartmentState.STA);


            drawing.Start();
            updating.Start();
            thread.Start();
        }

        private void Pressed(ConsoleKey key)
        {
            if (key == ConsoleKey.E)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixZ(2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.Q)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixZ(-2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.W)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixX(2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.S)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixX(-2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.A) 
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixY(-2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.D)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.RotationMatrixY(2), mesh.Vertices[i]);
            }
            if (key == ConsoleKey.OemPlus)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.ScaleMatrix * 2, mesh.Vertices[i]);
            }
            if (key == ConsoleKey.OemMinus)
            {
                BaseShape shape = (BaseShape)Shape;
                Mesh mesh = shape.Mesh;

                for (int i = 0; i < mesh.Vertices.Length; i++)
                    mesh.Vertices[i] = Matrix.Multiply(Matrix.ScaleMatrix / 2, mesh.Vertices[i]);
            }
            if (key == ConsoleKey.Enter)
            {
                var dialog = new OpenFileDialog();
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    Shape = new OBJParser().Import(dialog.FileName);

                }
            }
        }

        public void Update()
        {
            Thread.Sleep(32);
            Update();
        }

        public void Draw()
        {
            Graphics.Draw(true, Shape);
            Thread.Sleep(32);
            Draw();
        }

    }
}
