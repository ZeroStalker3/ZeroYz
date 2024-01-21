using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZeroYz.ClassHelper;

namespace ZeroYz.DataFilesApp
{
   
    /// <summary>
    /// Логика взаимодействия для PageStudent.xaml
    /// </summary>
    public partial class PageStudent : Page
    {
        private string NameStudent;
        public int StudentId;

        public PageStudent(Student student)
        {
            InitializeComponent();

            //TxtLogin.Text = UserControlHelp.LoginUser;

            NameStudent = student.Name;
            StudentId = student.Id;
            TxtLogin.Text = NameStudent;
            GridList.ItemsSource = OdbConnectHelper.entObj.Journal.Where(x => 
            x.idStudent == student.Id).ToList();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
