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
using System.Windows.Controls;
using System.IO;
using System.Text.Json;

namespace DescApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }


        private void RegisterButtonNavigate(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(ageInput.Text, out int age))
            {
                MessageText.Text = "❌ access denied 403 http error!";
                MessageText.Foreground = Brushes.Red;
                return;
            }
            if (age < 18)
            {
                MessageText.Text = "❌ Доступ запрещен";
                MessageText.Foreground = Brushes.AliceBlue;
                return;
            }
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        private bool CheckLogin(string username , string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password); // чекает на пустоту инпута
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            string username = usernameBox.Text;
            string password = passwordBox.Password;
            string age = ageInput.Text;

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                MessageText.Text = "❌ Заполните все поля!";
                MessageText.Foreground = Brushes.Red;
                return;
            }

            string dataPath = "login.json";
            var loginUsers = new List<LoginUser>();

            if (File.Exists(dataPath))
            {
                string js = File.ReadAllText(dataPath);
                if (!string.IsNullOrEmpty(js))
                {
                    loginUsers = JsonSerializer.Deserialize<List<LoginUser>>(js);
                }
            }

            if (loginUsers.Any(j => j.UserName == username))
            {
                MessageText.Text = $"Юзер {username} уже существует ";
                return;
            }

            loginUsers.Add(new LoginUser { Age = age, UserName = username, Password = password });

            var options = new JsonSerializerOptions { WriteIndented = true };
            string updateJson = JsonSerializer.Serialize(loginUsers, options);
            File.WriteAllText(dataPath , updateJson);

            if (CheckLogin(username , password))
            {
                MessageText.Text = "✅ Успешный вход!";
                MessageText.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                MessageText.Text = "❌ Неверный логин или пароль";
                MessageText.Foreground = System.Windows.Media.Brushes.White;
            }


            //if (login.Text != "123" || password.Password != "123")
            //{
            //    errMessage.Content = "invalid login or password";
            //}
            //else
            //{
            //    var w = new MainWindow();
            //    w.Show();
            //    Close();
            //} //  проверка логина


        }
    }
}
