using System.Drawing;
using System.Drawing.Imaging;

namespace cdevpopcreator
{
    internal class PrintScreenManager
    {
        private PrintScreenManager() {
            this.setPrintFullscreenDefault();
        }

        private static PrintScreenManager _instance;

        public static PrintScreenManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new PrintScreenManager();

            }
            return _instance;
        }



        private int xSize {  get; set; }
        private int ySize { get; set; }
        private int dxPosStart { get; set; } = 0;
        private int dyPosStart { get; set; } = 0;
        private int dxPosEnd { get; set; } = 0;
        private int dyPosEnd { get; set; } = 0;

        private string filepath { get; set; }

        public void setFilepath(string filepath)
        {
            this.filepath = filepath;
        }
        public string getFilepath()
        {
            return this.filepath;

        }

        public void setPrintFullscreenDefault()
        {
            this.xSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.ySize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        }

        public string screenSizeToString()
        {
            return $"Set the X to {this.xSize} and Y to {this.ySize}";
        }

 

        public Bitmap takePrint()
        {

            Bitmap bmp = new Bitmap(this.xSize, this.ySize);

            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(dxPosStart, dyPosStart, dxPosEnd, dyPosEnd, bmp.Size);
            g.Dispose();
            return bmp;

        }

        public void exportPrintToFile(Bitmap bmp)
        {       

            if (this.filepath == null)
            {
                return;
            }
            bmp.Save(this.filepath, ImageFormat.Png);
            bmp.Dispose();

            return;
        }

        
        public void setBoundaries(int xLeftPoint, int yLeftPoint, int xRightPoint, int yRightPoint)
        {
            this.dxPosStart = xLeftPoint;
            this.dyPosStart = yLeftPoint;
            this.dxPosEnd = xRightPoint;
            this.dyPosEnd = yRightPoint;

        }
    
        

        
    }
}