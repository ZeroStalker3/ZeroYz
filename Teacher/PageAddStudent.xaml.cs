using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZeroYz.DataFilesApp;

namespace ZeroYz.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        public PageAddStudent()
        {
            InitializeComponent();

            CmbSpecial.SelectedValuePath = "Id";
            CmbSpecial.DisplayMemberPath = "Name";
            CmbSpecial.ItemsSource = OdbConnectHelper.entObj.Special.ToList();

            CmbYear.SelectedValuePath = "Id";
            CmbYear.DisplayMemberPath = "Year";
            CmbYear.ItemsSource = OdbConnectHelper.entObj.YearAdd.ToList();

            CmbFT.SelectedValuePath = "Id";
            CmbFT.DisplayMemberPath = "Name";
            CmbFT.ItemsSource = OdbConnectHelper.entObj.FormTime.ToList();

            CmbNG.SelectedValuePath = "Id";
            CmbNG.DisplayMemberPath = "Name";
            CmbNG.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();
        }

        /// <summary>
        /// Логика работы добавления студента(ов)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student stdObj = new Student()
                {
                    Name = TbNameStudent.Text,
                    Special = CmbSpecial.SelectedItem as Special,
                    YearAdd = CmbYear.SelectedItem as YearAdd,
                    FormTime = CmbFT.SelectedItem as FormTime,
                    NameGroup = CmbNG.SelectedItem as NameGroup
                };

                OdbConnectHelper.entObj.Student.Add(stdObj);
                OdbConnectHelper.entObj.SaveChanges();
                MessageBox.Show("Ученик " + stdObj.Name + " успешно добавлен в базу", "Уведомление",
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
