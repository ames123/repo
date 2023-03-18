using System;
using System.Windows.Forms;

namespace Wspolbierzne
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
