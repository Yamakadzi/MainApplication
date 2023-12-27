using ProductAccounting.Data;
using ProductAccounting.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProductAccounting
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        public static (string?, bool) Validation_User(string? login, string? password, string? email = null) 
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return ("Заполните все поля данных", false);
            }
            else if (login.Length > 50)
            {
                return ("Максимальная длина логина 50 символов", false);
            }
            else if (password.Length > 50)
            {
                return ("Максимальная длина пароля 50 символов", false);
            }
            if (email != null  )
            {
                if (email.Length > 50)
                {
                    return ("Максимальная длина почты 50 символов", false);
                }
            }

            return (null, true);
            
        }
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            using var context = new MarketContext();
            var user = context.Users.FirstOrDefault(u => u.Login == LoginTextBox.Text || u.Email == EmailTextBox.Text);
            try
            {
                var valid_result = Validation_User(LoginTextBox.Text, PasswordBox.Password, EmailTextBox.Text);
                if (!valid_result.Item2)
                {
                    MessageBox.Show(valid_result.Item1);
                }
                else
                {
                    if (user == null)
                    {
                        User user1 = new User();
                        user1.Login = LoginTextBox.Text;
                        user1.Email = EmailTextBox.Text;
                        user1.Password = PasswordBox.Password;


                        context.Users.Add(user1);
                        context.SaveChanges();
                        MessageBox.Show("Вы зарегистрировались");

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь с таким логином или почтой существует, придумайте другой");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Данные введены неправильно {ex.Message.ToString()}");
            }
        }
    }
}
