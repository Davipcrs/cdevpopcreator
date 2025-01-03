using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdevpopcreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintScreenManager printer = PrintScreenManager.getInstance();
            printer.setPrintFullscreenDefault();
            Console.WriteLine(printer.screenSizeToString());
            printer.setFilepath(@"C:\temp\test.png");
            printer.exportPrintToFile(printer.takePrint());
            Console.ReadLine();
        }
    }
}
