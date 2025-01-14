using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace cdevpopcreator
{
    internal class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {

            Application app = new Application();
            app.Run(new MainWindow());
        }
    }
}
