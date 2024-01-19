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
    /// Логика взаимодействия для PageEditEvalStudent.xaml
    /// </summary>
    public partial class PageEditEvalStudent : Page
    {
        private string NameStudent;
        public PageEditEvalStudent(Student student)
        {
            InitializeComponent();

            Name.Text = student.Name;
            NameStudent = student.Name;
 
            GridListStudent.ItemsSource = OdbConnectHelper.entObj.Journal.Where(x => x.idStudent == student.Id).ToList();
            GridListStudent.SelectedIndex = 0;
            GridListStudent.Columns[0].IsReadOnly = true;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            History historyObj = new History()
            {
                IdTeacher = 2 ,
                IdStudent = 2,
                IdStatus = 2,
                DateEvent
            };

            OdbConnectHelper.entObj.SaveChanges();
            MessageBox.Show("Данные успешно изменены у студента" + NameStudent, 
                "Уведомления", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
