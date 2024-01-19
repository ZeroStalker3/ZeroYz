using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZeroYz.DataFilesApp;

namespace ZeroYz.Teacher
{
    /// <summary>
    /// Логика взаимодействия для PageDeleteStudent.xaml
    /// </summary>
    public partial class PageDeleteStudent : Page
    {
        public PageDeleteStudent()
        {
            InitializeComponent();
            SelectGroup.SelectedValuePath = "Id";
            SelectGroup.DisplayMemberPath = "Name";
            SelectGroup.ItemsSource = OdbConnectHelper.entObj.NameGroup.ToList();

            GridList.ItemsSource = OdbConnectHelper.entObj.Student.ToList();
        }

        private void SelectGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int select = Convert.ToInt32(SelectGroup.SelectedValue);
            GridList.ItemsSource = OdbConnectHelper.entObj.Student.Where(x => x.IdNameGroup == select).ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (GridList.SelectedItems.Count > 0)
                {
                    for(int i = 0; i < GridList.SelectedItems.Count; i++)
                    {
                        Student studentObj = GridList.SelectedItems[i] as Student;
                        OdbConnectHelper.entObj.Student.Remove(studentObj);

                        MessageBox.Show("Данных о студенте удалены ",
                                          "Уведомление",
                                          MessageBoxButton.OK,
                                          MessageBoxImage.Information);

                        OdbConnectHelper.entObj.SaveChanges();
                        GridList.ItemsSource = OdbConnectHelper.entObj.Student.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Данных в талице нету ",
                        "Уведомление",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения " + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
