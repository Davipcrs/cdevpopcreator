using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace cdevpopcreator
{
    internal class FSHelper
    {

        private FSHelper() { }

        private static FSHelper _instance;

        public static FSHelper getInstance()
        {
            if (_instance == null)
            {
                _instance = new FSHelper();

            }
            return _instance;
        }

        private String outputFolder = "";

        public void setOutputFolder(String outputFolder)
        {
            if (outputFolder[outputFolder.Length - 1] == @"\"[0]) 
            {
                this.outputFolder = outputFolder;
            }
            else
            {
                this.outputFolder = outputFolder + @"\" ;
            }

            
        }

        public String getOutputFolder()
        {
            return this.outputFolder;
        }
        public void SaveFileScreenShot(string filename, Bitmap data)
        {
            data.Save(outputFolder + filename);
            return;
        }


        public void SaveMDFile(string filename, string MDData)
        {
            try
            {
                // Write the string to the file
                File.WriteAllText(outputFolder + filename, MDData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


    }
}
