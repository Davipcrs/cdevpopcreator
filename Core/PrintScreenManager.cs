using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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


        public void setPrintFullscreenDefault()
        {
            this.xSize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            this.ySize = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        }

        public string screenSizeToString()
        {
            return $"Set the X to {this.xSize} and Y to {this.ySize}";
        }

 

        public Bitmap takeScreenshot()
        {

            Bitmap bmp = new Bitmap(this.xSize, this.ySize);

            Graphics g = Graphics.FromImage(bmp);
            
            Point cursorPos = Cursor.Position;
            
            g.CopyFromScreen(dxPosStart, dyPosStart, dxPosEnd, dyPosEnd, bmp.Size);
            
            drawArrow(g, cursorPos);
            
            g.Dispose();
            return bmp;

        }

        public void exportPrintToFile(Bitmap bmp)
        {       

            return;
        }

        
        public void setBoundaries(int xLeftPoint, int yLeftPoint, int xRightPoint, int yRightPoint)
        {
            this.dxPosStart = xLeftPoint;
            this.dyPosStart = yLeftPoint;
            this.dxPosEnd = xRightPoint;
            this.dyPosEnd = yRightPoint;

        }

        private static void drawArrow(Graphics g, Point cursorPos)
        {
            // Define the arrow size and direction
            int arrowLength = 30;
            int arrowWidth = 15;

            // Create an arrow pointing down-right
            Point[] arrowPoints = {
            cursorPos,                              // Tip of the arrow
            new Point(cursorPos.X - arrowWidth, cursorPos.Y - arrowWidth), // Top left of the arrow base
            new Point(cursorPos.X, cursorPos.Y - arrowWidth / 2),         // Middle left of the arrow base
            new Point(cursorPos.X + arrowWidth, cursorPos.Y - arrowWidth), // Top right of the arrow base
        };

            // Draw the arrow
            using (Brush brush = new SolidBrush(Color.Red))
            {
                g.FillPolygon(brush, arrowPoints);
            }
        }




    }
}