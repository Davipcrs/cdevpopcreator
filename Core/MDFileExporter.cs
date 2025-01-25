using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace cdevpopcreator
{
    internal class MDFileExporter
    {

        private MDFileExporter() { }    
        private static MDFileExporter _instance;

        public static MDFileExporter getInstance() {
            if (_instance == null)
            {
                _instance = new MDFileExporter();

            }
            return _instance;
        }
        private string MDString;

        public string getMDData()
        {
            return MDString;
        }

        public void createMDString() { }
        public void addPrintToMDString(string filename) {
            MDString = MDString + "  \n" + $"![{filename}](./{filename})";
        }
        public void addEventToMDString(string eventStringData) {
            MDString = MDString + "  \n" + eventStringData;
            return; 
        }
    }
}
