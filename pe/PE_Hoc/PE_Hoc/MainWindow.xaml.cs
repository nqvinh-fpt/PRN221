
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Q1.Models;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PE_Hoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LuyenOnThiDBContext context;
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            context = new LuyenOnThiDBContext();
            /*loadProduct();*/
            loadCategory();
        }

        public void loadProduct()
        {
            List<Product> list = context.Products.Include(x=>x.Category).ToList();
            lvProduct.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product =new Product();
            if(product != null)
            {

            }
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Name not null");
                return;
            }
            product.ProductName= txtName.Text;
            product.CategoryId=(cbCategory.SelectedItem as Category).CategoryId;

            product.Discontinued = rbtnTrue.IsChecked == true;
            product.QuantityPerUnit = txtQuantity.Text;
            context.Products.Add(product);
            context.SaveChanges();
            loadProduct();
            MessageBox.Show("Add done");
        }
        public void loadCategory()
        {
            cbCategory.ItemsSource = context.Categories.ToList();
            cbCategory.SelectedIndex = 0;
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Id khong hop le");
                return;
            }
            try
            {
                Product product = context.Products.Include(x =>x.OrderDetails).FirstOrDefault(p => p.ProductId == int.Parse(txtID.Text));
                if(product != null)
                {
                    if(product.OrderDetails.Count > 0)
                    {
                        context.OrderDetails.RemoveRange(product.OrderDetails);
                    }
                    context.Products.Remove(product);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Delete ok");
                    }
                }
                else
                {
                    MessageBox.Show("San pham khong ton tai");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Id khong hop le");
            }
            loadProduct();
        }

        private void lvProduct_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Product item = (sender as ListView).SelectedItem as Product;
            if(item != null)
            {
                txtID.Text= item.ProductId.ToString();
                txtName.Text= item.ProductName.ToString();
                txtQuantity.Text = item.QuantityPerUnit.ToString();
                cbCategory.SelectedItem = item.Category;
                rbtnTrue.IsChecked = true;
                rbtnFalse.IsChecked = item.Discontinued==false;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Id khong hop le");
                return;
            }
            try
            {
                Product product = context.Products.FirstOrDefault(p => p.ProductId == int.Parse(txtID.Text));
                if(product != null)
                {
                    product.ProductName = txtID.Text;
                    product.QuantityPerUnit = txtQuantity.Text;
                    product.CategoryId = (cbCategory.SelectedItem as Category).CategoryId;
                    product.Discontinued = rbtnTrue.IsChecked == true;
                    product.QuantityPerUnit = txtQuantity.Text;
                    context.Products.Update(product);
                    if (context.SaveChanges() > 0)
                    {
                        
                        MessageBox.Show("Update done");
                    }
                    else
                    {
                        MessageBox.Show("Id khong hop le");
                    }
                    loadProduct();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Id khong hop le");
            }
            
        }

        private void btnSaveFile1_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".json";
            saveFileDialog.Filter =  "JSON Files (*.json)|*.json|All Files (*.*)|*.*" ; ;

            if (saveFileDialog.ShowDialog() == true)
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };
                List<Product> productList = context.Products.ToList();
                productList.ForEach(x =>
                {
                    x.Category = null;
                });
                string jsonContent = JsonSerializer.Serialize(context.Products,jsonOptions);
                File.WriteAllText(saveFileDialog.FileName, jsonContent);
                MessageBox.Show("Save ok");
            }
            
        
        }

        private void btnLoadFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*"; ;
            if(openFileDialog.ShowDialog() == true)
            {
                string jsonContent = File.ReadAllText(openFileDialog.FileName);
                List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonContent);
                lvProduct.ItemsSource= products;
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            loadProduct();
        }
    }
}