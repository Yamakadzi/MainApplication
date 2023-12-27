using Microsoft.EntityFrameworkCore;
using ProductAccounting.Data;
using ProductAccounting.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProductAccounting
{
    /// <summary>
    /// Логика взаимодействия для MyProductsWindow.xaml
    /// </summary>
    public partial class MyProductsWindow : Window
    {
        
        public MyProductsWindow()
        {
            
            InitializeComponent();
            using var context = new MarketContext();

              var gridInformation = context.StoredProducts
                   .Include(gridInformation => gridInformation.IdUserNavigation)
                   .Select(x => new { x.NameProduct, x.ShelfLife, x.Count,x.IdUser })
                   .Where(x => x.IdUser == CurrentUser.currentUser)
                   .ToList();
               DGridMyProducts.ItemsSource = gridInformation;
            
        }
        private void ShoppingList_Click(object sender, RoutedEventArgs e)
        {
            ShoppingListWindow shoppingListWindow = new ShoppingListWindow();
            shoppingListWindow.Show();
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            var rowData = (dynamic)removeButton.DataContext;
            string nameProduct = rowData.NameProduct;
            DateTime shelfLife = rowData.ShelfLife;
            using (var context = new MarketContext())
            {
                var product = context.StoredProducts.FirstOrDefault(x => x.NameProduct == nameProduct && x.ShelfLife == shelfLife);
                if (product != null)
                {
                    context.StoredProducts.Remove(product);
                    context.SaveChanges();
                    MessageBox.Show("Продукт удален");
                }
                var gridInformation = context.StoredProducts
                .Include(gridInformation => gridInformation.IdUserNavigation)
                .Select(x => new { x.NameProduct, x.ShelfLife, x.Count ,x.IdUser })
                .Where(x => x.IdUser == CurrentUser.currentUser)
                .ToList();
                DGridMyProducts.ItemsSource = gridInformation;
            }
        }
        
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using var context = new MarketContext();
            var gridIndormation = context.StoredProducts;

            string searchText = SearchTextBox.Text;
            var filteredData = gridIndormation
                .Where(x => x.NameProduct.Contains(searchText) && x.IdUser == CurrentUser.currentUser).ToList() ;

            DGridMyProducts.ItemsSource = filteredData;
            
        }
        private void AddMyProduct_Click(object sender, RoutedEventArgs e)
        {
            AddMyProduct addMyProduct = new AddMyProduct();
            addMyProduct.Show();
            this.Close();
        }
    }
}
