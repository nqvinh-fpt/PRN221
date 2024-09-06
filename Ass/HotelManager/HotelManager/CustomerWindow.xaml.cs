using HotelManager.Models;
using Microsoft.EntityFrameworkCore;
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

namespace HotelManager
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly HotelManagerContext _context;

        public CustomerWindow(HotelManagerContext context)
        {
            InitializeComponent();
            _context = context;
            LoadCustomerList();
        }

        public void LoadCustomerList()
        {
            lvCustomer.ItemsSource = _context.Customers.ToList();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
        private void lvCustomer_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = (Customer)(sender as ListView).SelectedItem;

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = GetCustomerObject();
                Customer c = GetCustomerByID(customer.CustomerId);
                if (c != null)
                {
                    _context.Entry<Customer>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadCustomerList();
                    MessageBox.Show($"{c.Name} updated successful", "Update customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Customer");
            }
        }

        private Customer GetCustomerObject()
        {

            Customer customer = null;
            try
            {
                customer = new Customer
                {
                    CustomerId = int.Parse(txtCustomerID.Text),
                    Name = txtName.Text,
                    PhoneNumber = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Customer");
            }
            return customer;
        }

        private Customer GetCustomerByID(int CustomerID)
        {
            Customer customer = null;
            try
            {
                customer = _context.Customers.SingleOrDefault(customer => customer.CustomerId == CustomerID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Customer By ID");
            }
            return customer;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = GetCustomerObject();
                Customer c = GetCustomerByID(customer.CustomerId);
                if (c != null)
                {
                    _context.Customers.Remove(c);
                    _context.SaveChanges();
                    LoadCustomerList();
                    MessageBox.Show($"{c.GetType} deleted successful", "Delete Customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Customer");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = GetCustomerObject();
                if (customer != null)
                {
                    customer.CustomerId = 0;
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    LoadCustomerList();
                    MessageBox.Show($"{customer.Name} inserted successful", "Insert Customer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Customer");
            }
        }

        private void btnBookingMN_Click_1(object sender, RoutedEventArgs e)
        {

        }



        private void btncustomerMN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_context);
            mainWindow.Close();
            CustomerWindow customerWindow = new CustomerWindow(_context);
            customerWindow.Show();
            Close();
        }
        public List<Customer> SearchCustomer(string type, string text)
        {
            switch (type)
            {

                case "Name":
                    return _context.Customers.ToList().FindAll(Customer => Customer.Name.Contains(text));
                case "Phone Number":
                    return _context.Customers.ToList().FindAll(Customer => Customer.PhoneNumber.Contains(text));

                case "Email":
                    return _context.Customers.ToList().FindAll(Customer => Customer.Email.Contains(text));
                case "Address":
                    return _context.Customers.ToList().FindAll(Customer => Customer.Address.Contains(text));
                default:
                    break;
            }
            return _context.Customers.ToList();


        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)cbbSearch.SelectedItem;
            if (selectedItem != null)
            {
                lvCustomer.ItemsSource = SearchCustomer(selectedItem.Content.ToString(), txtSearch.Text);
            }
        }

        private void btnBookingMN_Click(object sender, RoutedEventArgs e)
        {
            
            BookingWindow bookingWindow = new BookingWindow(_context);
            bookingWindow.Show();
            Close();
        }

        private void btnRoomMN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(_context);
            mainWindow.Show();
            Close();
        }

        private void btnReportMN_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow(_context);
            reportWindow.Show();
            Close();
        }
    }

}
