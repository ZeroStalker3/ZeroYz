using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ZeroYz.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new PageRegistration());
        }

        /// <summary>
        /// Авторизация пользователей в приложении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.entObj.User.FirstOrDefault(
                    x => x.Login == LoginTxb.Text && x.Password == PasswordBx.Password
                    );
                if (userObj == null)
                {
                    /// добавть больше конкретики, тоесть если введен неверный пароль то так и пишет
                    MessageBox.Show("Такой пользователь отсутсвует в приложения",
                        "Уведомление",
                         MessageBoxButton.OK,
                         MessageBoxImage.Warning);
                    FrameApp.frmObj.Navigate(new PageRegistration());
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            //MessageBox.Show("Здравствуйте, " + userObj.Login + " Ученик",
                            //    "Уведомление",
                            //     MessageBoxButton.OK,
                            //     MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new PageStudent());
                            break;
                        case 2:
                            //MessageBox.Show("Здравствуйте, "+ userObj.Login + " Учитель",
                            //    "Уведомление",
                            //     MessageBoxButton.OK,
                            //     MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new PageTeacher());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения", "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
