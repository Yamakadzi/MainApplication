using ProductAccounting.Data;
using ProductAccounting.Models;
using System;
using System.Windows;

namespace ProductAccounting
{
    /// <summary>
    /// Логика взаимодействия для AddProductShoppintListWindow.xaml
    /// </summary>
    public partial class AddProductShoppintListWindow : Window
    {
       
        public AddProductShoppintListWindow()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            using var context = new MarketContext();
            try
            {
                if (string.IsNullOrEmpty(NameProductsTextBox.Text) || string.IsNullOrEmpty(CountProductsTextBox.Text))
                {
                    MessageBox.Show("Заполните все поля данных");
                }
                else if (NameProductsTextBox.Text.Length > 50)
                {
                    MessageBox.Show("Максимальная длина названия продукта 50 символов");
                }
                else if (!int.TryParse(CountProductsTextBox.Text, out int count) || count > int.MaxValue)
                {
                    MessageBox.Show("Некорректное количество продукта");
                }
                else
                {
                    ShoppingList shoppingList = new ShoppingList();
                    shoppingList.NameProduct = NameProductsTextBox.Text;
                    shoppingList.Count = Convert.ToInt32(CountProductsTextBox.Text);
                    shoppingList.IdUser = CurrentUser.currentUser;

                    context.ShoppingLists.Add(shoppingList);
                    context.SaveChanges();
                    MessageBox.Show("Продукт был добавлен в список покупок");
                    NameProductsTextBox.Clear();
                    CountProductsTextBox.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Данные введены неправильно {ex.Message.ToString()}");
            }
        }

        private void ProductList_Click(object sender, RoutedEventArgs e)
        {
            ShoppingListWindow shoppingListWindow = new ShoppingListWindow();
            shoppingListWindow.Show();
            this.Close();
        }
    }
}
