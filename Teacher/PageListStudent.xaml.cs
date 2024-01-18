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

namespace ZeroYz.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageListStudent.xaml
    /// </summary>
    public partial class PageListStudent : Page
    {
        public PageListStudent()
        {
            InitializeComponent();

            CmbSelectyGroup.SelectedValuePath = "Id";
            CmbSelectyGroup.DisplayMemberPath = "Name";
            CmbSelectyGroup.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();

            GridList.ItemsSource = OdbConnectHelper.entObj.Student.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageJournalStudent((sender as Button).DataContext as Student));
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int Select = Convert.ToInt32(CmbSelectyGroup.SelectedValue);
            GridList.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == Select).ToList();
            GridList.SelectedIndex = 0;
        }
    }
}
