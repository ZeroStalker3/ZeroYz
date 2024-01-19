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
using ZeroYz.ClassHelper;
using ZeroYz.Director;

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

            if (Properties.Settings.Default.SaveLogin != string.Empty)
            {
                LoginTxb.Text = Properties.Settings.Default.SaveLogin;
            }
        }

        public void RememberMe()
        {
            if (ChkSaveLogin.IsChecked == true)
            {
                Properties.Settings.Default.SaveLogin = LoginTxb.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.SaveLogin = "";
                Properties.Settings.Default.Save();
            }
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
                    UserControlHelp.IdUser = userObj.ID;
                    UserControlHelp.LoginUser = userObj.Name;
                    switch (userObj.IdRole)
                    {
                        case 1:
                            RememberMe();
                            UserControlHelp.LoginUser = LoginTxb.Text;
                            FrameApp.frmObj.Navigate(new PageStudent());
                            break;
                        case 2:
                            RememberMe();
                            FrameApp.frmObj.Navigate(new PageTeacher());
                            break;
                        case 3:
                            WindowDirector windowDirector = new WindowDirector();
                            windowDirector.Show();
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
