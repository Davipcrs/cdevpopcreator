using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cdevpopcreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon nIcon;
        

        public MainWindow()
        {
            this._nIconCustomInit();
            InitializeComponent();
            
        }

        private void StartSavingButtonClick(object sender, RoutedEventArgs e)
        {
            
           
            this.Visibility = Visibility.Hidden;
            // this.WindowState = System.Windows.WindowState.Minimized;
            
            
        }

        private void _nIconCustomInit()
        {
            this.nIcon = new NotifyIcon();
            this.nIcon.Icon = new System.Drawing.Icon(@"D:\src\cdev-suite\camera.ico");
            this.nIcon.Visible = true;
            this.nIcon.BalloonTipTitle = "Teste SystemTray";
            this.nIcon.Text = "text";
            this.nIcon.BalloonTipText = "daw";
            this.nIcon.ContextMenuStrip = new ContextMenuStrip();
            this.nIcon.ContextMenuStrip.Items.Add("Change visibility", null, (_, _) => { this.Visibility = Visibility.Visible; });
        }

 

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
