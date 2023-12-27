using ProductAccounting.Data;
using ProductAccounting.Models;
using System;
using System.Windows;

namespace ProductAccounting
{
    /// <summary>
    /// Логика взаимодействия для AddMyProduct.xaml
    /// </summary>
    public partial class AddMyProduct : Window
    {
        public AddMyProduct()
        {
            InitializeComponent();
            var nameProduct = PurchasedProduct.nameProduct;
            var countProduct = PurchasedProduct.count;
            NameProductsTextBox.Text = nameProduct;
            CountProductsTextBox.Text = countProduct.ToString();

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            using var context = new MarketContext();

            try
            {
                if (string.IsNullOrEmpty(NameProductsTextBox.Text))
                {
                    MessageBox.Show("Заполните все поля данных");
                }
                else
                {
                    StoredProduct product = new StoredProduct();

                    product.NameProduct = NameProductsTextBox.Text;
                    DateTime? selectedDate = ShelfLifeCalendar.SelectedDate;

                    product.ShelfLife = selectedDate.Value.Date;
                    product.Count = Convert.ToInt32(CountProductsTextBox.Text);
                    product.IdUser = CurrentUser.currentUser;

                    context.StoredProducts.Add(product);
                    context.SaveChanges();
                    MessageBox.Show("Продукт был добавлен в хранимые продукты");
                    PurchasedProduct.nameProduct = null;
                    PurchasedProduct.count = null;

                    NameProductsTextBox.Clear();
                    CountProductsTextBox.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" Данные введены неправильно {ex.Message.ToString()}");
            }
        }

        private void MyProduct_Click(object sender, RoutedEventArgs e)
        {
            MyProductsWindow myProduct = new MyProductsWindow();
            myProduct.Show();
            this.Close();
        }
    }
}
