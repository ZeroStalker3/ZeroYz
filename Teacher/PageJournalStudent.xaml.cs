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
    /// Логика взаимодействия для PageJournalStudent.xaml
    /// </summary>
    public partial class PageJournalStudent : Page
    {
        public PageJournalStudent(Student student)
        {
            InitializeComponent();
            Name.Text = student.Name;
            GridListStudent.ItemsSource = OdbConnectHelper.entObj.Journal.Where(x => x.idStudent == student.Id).ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                print.PrintVisual(DataPrint, "");
            }
            else
            {
                MessageBox.Show("Пользователь прервал печать", 
                    "Уведомления", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
