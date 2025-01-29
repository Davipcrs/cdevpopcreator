using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


// @DOCSTART
// ### FSHelper.cs (FSHelper) @NL
// File Responsible to the FileSystem in the application @NL
// Defines the OutputFolder, used on the app @NL
// Also is responsible to save the Image files and the MD files. @NL
// @DOCEND

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

        // @DOCSTART
        // Import implementation: @NL
        // @CBS cs

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
        // @CBE
        // @NL
        // @DOCEND

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
