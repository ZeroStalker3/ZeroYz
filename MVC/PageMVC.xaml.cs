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
using ZeroYz.MVC.Controller;

namespace ZeroYz.MVC
{
    /// <summary>
    /// Логика взаимодействия для PageMVC.xaml
    /// </summary>
    public partial class PageMVC : Page
    {
        public PageMVC()
        {
            InitializeComponent();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {

            ControllerLogin controllerLogin = new ControllerLogin();

            MessageBox.Show(controllerLogin.CheckLoginOdb(TxbLogin.Text));
        }
    }
}
