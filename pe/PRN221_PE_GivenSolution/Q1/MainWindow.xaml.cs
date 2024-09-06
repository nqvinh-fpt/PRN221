using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Q1.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LuyenOnThiDBContext context;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            context = new LuyenOnThiDBContext();
            //loadProduct();
            loadCategory();
        }

        public void loadProduct()
        {
            List<Product> list = context.Products.Include(x => x.Category).ToList();
            lvProduct.ItemsSource = list;
        }

        public void loadCategory()
        {
            cbCategory.ItemsSource = context.Categories.ToList();
            cbCategory.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Name ko dc de trong");
                return;
            }
            product.ProductName = tbName.Text;
            product.CategoryId = (cbCategory.SelectedItem as Category).CategoryId;
            product.QuantityPerUnit = tbQuantity.Text;
            product.Discontinued = rbTrue.IsChecked == true;

            context.Products.Add(product);
            context.SaveChanges();
            loadProduct();
            MessageBox.Show("Add ok");

        }

        private void lvProduct_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Product item = (sender as ListView).SelectedItem as Product;
            if (item != null)
            {
                tbId.Text = item.ProductId.ToString();
                tbName.Text = item.ProductName;
                tbQuantity.Text = item.QuantityPerUnit;
                cbCategory.SelectedItem = item.Category;
                rbTrue.IsChecked = true;
                rbFalse.IsChecked = item.Discontinued == false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Id ko hop le");
                return;
            }
            try
            {
                Product product = context.Products.FirstOrDefault(x => x.ProductId == int.Parse(tbId.Text));
                if (product != null)
                {
                    product.ProductName = tbName.Text;
                    product.QuantityPerUnit = tbQuantity.Text;
                    product.CategoryId = (cbCategory.SelectedItem as Category).CategoryId;
                    product.Discontinued = rbTrue.IsChecked == true;
                    context.Products.Update(product);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update ok");
                        loadProduct();
                    }
                }
                else
                {
                    MessageBox.Show("Sp ko ton tai");
                }
            }
            catch (System.Exception)
            {

                MessageBox.Show("Id ko hop le");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Id ko hop le");
                return;
            }
            try
            {
                Product product = context.Products.Include(x => x.OrderDetails).FirstOrDefault(x => x.ProductId == int.Parse(tbId.Text));
                if (product != null)
                {
                    if (product.OrderDetails.Count > 0)
                    {
                        context.OrderDetails.RemoveRange(product.OrderDetails);
                    }
                    context.Products.Remove(product);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Delete Ok");
                    }
                }
                else
                {
                    MessageBox.Show("San pham ko ton tai");
                }
            }
            catch (System.Exception)
            {

                MessageBox.Show("Id ko hop le");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {

                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true
                };

                List<Product> productList = context.Products.ToList();
                productList.ForEach(x =>
                {
                    x.Category = null;
                });

                string jsonContent = JsonSerializer.Serialize(productList, jsonOptions);

                File.WriteAllText(saveFileDialog.FileName, jsonContent);
                MessageBox.Show("Save ok");
            }

        }

        private void btnLoad(object sender, RoutedEventArgs e)
        {
            loadProduct();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string jsonConten = File.ReadAllText(openFileDialog.FileName);
                List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonConten);
                lvProduct.ItemsSource = products;
            }
        }
    }
}
