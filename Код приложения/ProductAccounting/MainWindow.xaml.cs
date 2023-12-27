using ProductAccounting.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProductAccounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public TextBox GetLoginTextBox()
        {
            return LoginTextBox;
        }

        public PasswordBox GetPasswordBox()
        {
            return PasswordBox;
        }
        public void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new MarketContext();
                var user = context.Users.FirstOrDefault(u => u.Login == LoginTextBox.Text && u.Password == PasswordBox.Password);

                if (user != null)
                {
                    MessageBox.Show($"Здравствуйте! {user.Login}");
                    CurrentUser.currentUser = user.IdUser;
                    MyProductsWindow myProducts = new MyProductsWindow();
                    myProducts.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или пароль неправильный");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
