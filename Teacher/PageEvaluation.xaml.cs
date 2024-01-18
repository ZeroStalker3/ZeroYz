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
    /// Логика взаимодействия для PageEvaluation.xaml
    /// </summary>
    public partial class PageEvaluation : Page
    {
        public PageEvaluation()
        {
            InitializeComponent();

            CmbDl.SelectedValuePath = "Id";
            CmbDl.DisplayMemberPath = "Name";
            CmbDl.ItemsSource = OdbConnectHelper.entObj.Disciplen.ToList();

            CmbStudent.SelectedValuePath = "Id";
            CmbStudent.DisplayMemberPath = "Name";

            CmbGroup.SelectedValuePath = "Id";
            CmbGroup.DisplayMemberPath = "Name";
            CmbGroup.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();

        }

        private void BtnAddEvaluation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Journal jourObj = new Journal()
                {
                    Student = CmbStudent.SelectedItem as Student,
                    Evaluation = Convert.ToInt32(CmbEval.Text),
                    Disciplen = CmbDl.SelectedItem as Disciplen,
                    NameGroup = CmbGroup.SelectedItem as NameGroup
                };

                OdbConnectHelper.entObj.Journal.Add(jourObj);
                OdbConnectHelper.entObj.SaveChanges();

                MessageBox.Show("Оценка поставлена", 
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                FrameApp.frmObj.GoBack();

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Критический сбор в работе приложения " + ex.Message.ToString(), "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedGroup = Convert.ToInt32(CmbGroup.SelectedValue);
            CmbStudent.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == SelectedGroup).ToList();
        }

        private void CmbEval_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "1234567890".IndexOf(e.Text) < 0;
        }

        private void CmbEval_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Convert.ToInt32(CmbEval.Text) >= 2 && Convert.ToInt32(CmbEval.Text) <= 5)
            { 
            CmbEval.Background = Brushes.LightGreen;
                CmbEval.BorderBrush = Brushes.Green;
                BtnAddEvaluation.IsEnabled = true;
            }
            else
            {
                CmbEval.Background = Brushes.LightCoral;
                CmbEval.BorderBrush = Brushes.Green;
                BtnAddEvaluation.IsEnabled = false;
            }
        }

        private void BtnBack_Click_2(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
