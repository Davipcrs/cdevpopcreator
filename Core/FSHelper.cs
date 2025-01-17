using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cdevpopcreator
{
    internal class FSHelper
    {

        public void SaveFileScreenShot(string filename, Bitmap data)
        {
            data.Save(filename);
            return;
        }


        public void SaveMDFile(string filename, string MDData)
        {
            return;
        }


    }
}
