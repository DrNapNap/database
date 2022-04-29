using System;

namespace UserInterface
{

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            GameWorld.Instance.Run();
        }
    }
}
