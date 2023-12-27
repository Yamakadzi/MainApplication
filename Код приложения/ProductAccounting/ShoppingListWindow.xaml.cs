using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OfficeOpenXml;
using ProductAccounting.Data;
using ProductAccounting.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProductAccounting
{
    /// <summary>
    /// Логика взаимодействия для ShoppingListWindow.xaml
    /// </summary>
    public partial class ShoppingListWindow : Window
    {

        public ShoppingListWindow()
        {

            InitializeComponent();
            using var context = new MarketContext();
            var gridInformation = context.ShoppingLists
               .Select(x => new { x.NameProduct, x.Count, x.IdUser })
               .Where(x => x.IdUser == CurrentUser.currentUser)
               .ToList();
            DGridProductsList.ItemsSource = gridInformation;
        }
        private void MyProducts_Click(object sender, RoutedEventArgs e)
        {
            MyProductsWindow myProductsWindow = new MyProductsWindow();
            myProductsWindow.Show();
            this.Close();
        }

        private void AddMyProducts_Click(object sender, RoutedEventArgs e)
        {
            AddProductShoppintListWindow addProductShoppintListWindow = new AddProductShoppintListWindow();
            addProductShoppintListWindow.Show();
            this.Close();
        }

        private void ExportListProduct_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (.xlsx)|.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("ShoppingList");
                    string query = $"SELECT NameProduct, Count FROM ShoppingList WHERE IdUser = '{CurrentUser.currentUser}'";
                    SqlConnection connection = new SqlConnection("data source=DESKTOP-GURUASM;initial catalog=practice;persist security info=True;user id=admin;password=admin;TrustServerCertificate=true;");
                    //SqlConnection connection = new SqlConnection("data source=prserver\\SQLEXPRESS;initial catalog=ispp0113;persist security info=True;user id=ispp0113;password=0113;TrustServerCertificate=true;");
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    worksheet.Cells["A1"].Value = "Название продукта";
                    worksheet.Cells["B1"].Value = "Количество";
                    int row = 2;
                    while (reader.Read())
                    {
                        string nameProduct = reader["NameProduct"].ToString();
                        int count = Convert.ToInt32(reader["Count"]);

                        worksheet.Cells[$"A{row}"].Value = nameProduct;
                        worksheet.Cells[$"B{row}"].Value = count;

                        row++;
                    }
                    reader.Close();
                    connection.Close();
                    FileInfo excelFile = new FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                }
                MessageBox.Show("Данные экспортированы");
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            var rowData = (dynamic)removeButton.DataContext;
            string nameProduct = rowData.NameProduct;
            int count = rowData.Count;
            using (var context = new MarketContext())
            {
                var product = context.ShoppingLists.FirstOrDefault(x => x.NameProduct == nameProduct && x.Count == count);
                if (product != null)
                {
                    context.ShoppingLists.Remove(product);
                    context.SaveChanges();
                    MessageBox.Show("Продукт удален");
                }
                var gridInformation = context.ShoppingLists
                .Include(gridInformation => gridInformation.IdUserNavigation)
                .Select(x => new { x.NameProduct, x.Count, x.IdUser })
                .Where(x => x.IdUser == CurrentUser.currentUser)
                .ToList();
                DGridProductsList.ItemsSource = gridInformation;
            }
        }
        private void PurchazedButton_Click(object sender, RoutedEventArgs e)
        {
            ShoppingList shoppingList = new ShoppingList();
            Button removeButton = (Button)sender;
            var rowData = (dynamic)removeButton.DataContext;
            string nameProduct = rowData.NameProduct;
            int count = rowData.Count;
            using (var context = new MarketContext())
            {
                var product = context.ShoppingLists.FirstOrDefault(x => x.NameProduct == nameProduct && x.Count == count);
                if (product != null)
                {
                    //сохраняю в класс название и количество продукта
                    PurchasedProduct.nameProduct = product.NameProduct;
                    PurchasedProduct.count = Convert.ToInt32(product.Count);

                    //удаляю продукт
                    context.ShoppingLists.Remove(product);
                    context.SaveChanges();
                    MessageBox.Show("Выбранный продукт будет удален из списка покупок а перенесён в мои продукты ");

                    AddMyProduct addMyProduct = new AddMyProduct();
                    addMyProduct.Show();
                    this.Close();

                }
                var gridInformation = context.ShoppingLists
                .Include(gridInformation => gridInformation.IdUserNavigation)
                .Select(x => new { x.NameProduct, x.Count, x.IdUser })
                .Where(x => x.IdUser == CurrentUser.currentUser)
                .ToList();
                DGridProductsList.ItemsSource = gridInformation;
            }
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using var context = new MarketContext();
            var gridIndormation = context.ShoppingLists;

            string searchText = SearchTextBox.Text;
            var filteredData = gridIndormation
                .Where(x => x.NameProduct.Contains(searchText) && x.IdUser == CurrentUser.currentUser).ToList();

            DGridProductsList.ItemsSource = filteredData;

        }
    }
}
