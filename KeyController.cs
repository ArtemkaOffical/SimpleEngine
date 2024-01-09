namespace _2D
{
    public class KeyController
    {
        public delegate void KeyHandler(ConsoleKey key);
        public KeyHandler OnKeyPress = _ => { };

        public void Pressed()
        {
            OnKeyPress?.Invoke(Console.ReadKey(true).Key);
            Pressed();
        }

    }
}