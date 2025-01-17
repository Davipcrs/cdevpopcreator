using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private KeyboardMouseClickManager kbManager;
        private CancellationTokenSource cancellationTokenSource;
        private Task keyboardTask;
        private bool keyboardTaskIsRunning = false;

        public MainWindow()
        {
            this._nIconCustomInit();
            InitializeComponent();
            
        }

        public void StartKbThread()
        {
            if (!keyboardTaskIsRunning)
            {
                this.kbManager = new KeyboardMouseClickManager();
                this.cancellationTokenSource = new CancellationTokenSource();

                // Start the task with cancellation support
                this.keyboardTask = Task.Run(() => kbManager.Execute(cancellationTokenSource.Token), cancellationTokenSource.Token);

                keyboardTaskIsRunning = true;
            }

        }

        public void StopKbThread() {
            if (keyboardTaskIsRunning)
            {
                cancellationTokenSource.Cancel(); // Signal cancellation to the task
                try
                {
                    keyboardTask.Wait(); // Optionally wait for the task to finish
                }
                catch (AggregateException ex) when (ex.InnerExceptions.All(e => e is OperationCanceledException))
                {
                    
                }
                finally
                {
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = null;
                    keyboardTaskIsRunning = false;
                }
            }
        }

        private void StartSavingButtonClick(object sender, RoutedEventArgs e)
        {
            
           
            this.Visibility = Visibility.Hidden;
            this.StartKbThread();
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

 

        private void SelectDirectoryPathButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxTextChangedEvent(object sender, TextChangedEventArgs e)
        {

        }

        private void StopPopButtonClick(object sender, RoutedEventArgs e)
        {
            StopKbThread();
            MDFileExporter exporter =  MDFileExporter.getInstance();
            exporter.exportProjectToMDFile();

        }
    }
}
