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
using ZeroYz.ClassHelper;
using ZeroYz.DataFilesApp;

namespace ZeroYz.Director
{
    /// <summary>
    /// Логика взаимодействия для WindowDirector.xaml
    /// </summary>
    public partial class WindowDirector : Window
    {
        public WindowDirector()
        {
            InitializeComponent();

            TxtName.Text = UserControlHelp.LoginUser;

            OdbConnectHelper.entObj = new ZeroEntities();

            GridListHistory.ItemsSource = OdbConnectHelper.entObj.History.ToList();
        }

        private void IzmeneniaDannih()
        {

        }
    }
}
