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
using System.Windows.Shapes;
using System.IO;

namespace DescApp
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public void BackToLoginButton_Click(object sender , RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageText.Text = "Заполните все инпуты ";
                return;
            }

            if (password != confirmPassword)
            {
                MessageText.Text = "пароли не совпадают";
                return;
            }
            //string saveFile = File.ReadAllText("users.txt");

          

            MessageBox.Show($"                             ✅  {username} - РЕГИСТРАЦИЯ ПРОШЛА УСПЕШНО                      ");

            //MessageText.Text = "Регистрация успешно прошла ✅";
            MessageText.Foreground = System.Windows.Media.Brushes.White;

          

            System.Threading.Tasks.Task.Delay(2000).ContinueWith(_ =>
            {
                Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow(); // вызываем /
                    mainWindow.Show();
                    this.Close();
                });
            });

        }
    }
}
