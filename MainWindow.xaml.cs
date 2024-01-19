using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZeroYz.DataFilesApp;

namespace ZeroYz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool size = false;
        public MainWindow()
        {
            InitializeComponent();

            FrameApp.frmObj = FrmMain;
            FrmMain.Navigate(new PageMain.PageLogin());

            OdbConnectHelper.entObj = new ZeroEntities();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Resize_Click(object sender, RoutedEventArgs e)
        {
            if (size == false)
            {
                this.WindowState = WindowState.Maximized;
                size = true;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                size = false;
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
