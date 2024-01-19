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
using System.Windows.Shapes;
using System.Windows.Threading;
using ZeroYz.ClassHelper;
using ZeroYz.DataFilesApp;

namespace ZeroYz.Director
{
    /// <summary>
    /// Логика взаимодействия для WindowDirector.xaml
    /// </summary>
    public partial class WindowDirector : Window
    {
        bool logicdate = false;
        bool size = false;

        public WindowDirector()
        {
            InitializeComponent();


            TxtName.Text = UserControlHelp.LoginUser;

            OdbConnectHelper.entObj = new ZeroEntities();

            GridListHistory.Columns[3].CanUserSort = false;

            GridListHistory.ItemsSource = OdbConnectHelper.entObj.History.ToList();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += IzmeneniaDannih;
            timer.Start();
        }

        private void IzmeneniaDannih(object sender, object e)
        {
            var histories = OdbConnectHelper.entObj.History.ToList();
            GridListHistory.ItemsSource = histories;
            TotalTB.Text = histories.Count.ToString();

            var dateupdate = histories.OrderByDescending(x => x.DateEvent).FirstOrDefault();
            TxtDate.Text = dateupdate.DateEvent.ToShortDateString();

        }

        private void RbDec_Click(object sender, RoutedEventArgs e)
        {
            if(RbDec.IsChecked == true)
            {
                RbUp.IsChecked = false;
                GridListHistory.ItemsSource = OdbConnectHelper.entObj.History.OrderByDescending(x => x.DateEvent).ToList();
            }
        }   

        private void RbUp_Click(object sender, RoutedEventArgs e)
        {
            if(RbUp.IsChecked == true)
            {
                RbDec.IsChecked = false;
                GridListHistory.ItemsSource = OdbConnectHelper.entObj.History.OrderBy(x => x.DateEvent).ToList();
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.;
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
    }
}
