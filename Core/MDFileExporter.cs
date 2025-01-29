using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

// @DOCSTART
// ### MDFileExporter.cs (MDFileExporter) @NL
// File Responsible to the .md File in the application @NL
// Defines how the program stores the data in the markdown @NL
// @DOCEND


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

        // @DOCSTART
        // Import implementation: @NL
        // @CBS cs
        public void addPrintToMDString(string filename) {
            MDString = MDString + "  \n" + $"![{filename}](./{filename})";
        }
        public void addEventToMDString(string eventStringData) {
            MDString = MDString + "  \n" + eventStringData;
            return; 
        }
        // @CBE
        // @NL
        // @DOCEND
    }
}
