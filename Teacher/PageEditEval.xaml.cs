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
    /// Логика взаимодействия для PageEditEval.xaml
    /// </summary>
    public partial class PageEditEval : Page
    {
        private string NameStudent;

        public PageEditEval()
        {
            InitializeComponent();
            CmbSelectGroup.DisplayMemberPath = "Name";
            CmbSelectGroup.SelectedValuePath = "Id";
            CmbSelectGroup.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        /// <summary>
        /// Логика фильтра данных по группам студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageEditEvalStudent((sender as Button).DataContext as Student));
        }

        /// <summary>
        /// Логика данных по работе с редактированием оценок студентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSelectGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int select = Convert.ToInt32(CmbSelectGroup.SelectedValue);
            ListStudent.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == select).ToList();
            ListStudent.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            OdbConnectHelper.entObj.SaveChanges();
            //MessageBox.Show("Данные успешно изменены у студента" + student);
        }
    }
}
