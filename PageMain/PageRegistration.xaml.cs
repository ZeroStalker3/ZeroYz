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

namespace ZeroYz.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageRegistration.xaml
    /// </summary>
    public partial class PageRegistration : Page
    {
        public PageRegistration()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }

        /// <summary>
        /// Регистрация пользователей в приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OdbConnectHelper.entObj.User.Count(x => x.Login == LogingTB.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else 
            {
                try 
                {
                    User userObj = new User()
                    {
                        Name = LoginTB.Text,
                        Login = LogingTB.Text,
                        Password = Psw2.Password,
                        IdRole = 1
                    };
                    
                    OdbConnectHelper.entObj.User.Add(userObj);
                    OdbConnectHelper.entObj.SaveChanges();

                    MessageBox.Show("Пользователь создан", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    FrameApp.frmObj.GoBack();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбор работы", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        /// <summary>
        /// Проверка пароля на совпадение между полями:
        /// "Введите пароль" и "Повторите пароль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Psw2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Psw1.Text == Psw2.Password) 
            {
                CreateBtn.IsEnabled = true;
                Psw2.BorderBrush = Brushes.Green;
                Psw2.Background = Brushes.Green;
            }
            else 
            {
                CreateBtn.IsEnabled = false;
                Psw2.Background = Brushes.Red;
                Psw2.BorderBrush = Brushes.Red;
            }
        }
    }
}
