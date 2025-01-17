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
        public void exportProjectToMDFile() { }
        public void createMDString() { }
        public void addPrintToMDString() { 

     
        }
        public void addEventToMDString(string eventStringData) {
            MDString = MDString + eventStringData;
            return; 
        }
    }
}
