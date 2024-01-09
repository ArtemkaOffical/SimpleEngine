using System.Windows.Forms;

namespace _2D
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var fileDialog = new OpenFileDialog();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Engine simpleEngine = new Engine(fileDialog.FileName);
                simpleEngine.Start();
            }
        }
    }
}