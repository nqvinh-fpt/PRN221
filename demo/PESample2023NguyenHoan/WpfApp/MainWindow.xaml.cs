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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_Spr22Context _context;
        public MainWindow(PRN221_Spr22Context context)
        {
            InitializeComponent();
            _context = context;
            LoadEmployeeList();
        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeeID.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            rbMale.IsChecked = true;
            dtpDOB.SelectedDate= DateTime.Now;
            txtPhone.Text = string.Empty;
            txtIDNumber.Text = string.Empty;
        }
        private Employee GetEmployeeByID(int EmployeeID)
        {
            Employee employee = null;
            try
            {
                employee = _context.Employees.SingleOrDefault(employee => employee.Id== EmployeeID);
            }catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Get Employ By ID");
            }
            return employee;
        }
        private Employee GetEmployeeObject()
        {
            Employee employee = null;
            try
            {
                employee = new Employee
                {
                    Id = int.Parse(txtEmployeeID.Text),
                    Name = txtEmployeeName.Text,
                    Gender = rbMale.IsChecked == true ? "Male" : "Female",
                    Dob = dtpDOB.SelectedDate,
                    Phone= txtPhone.Text,
                    Idnumber = txtIDNumber.Text
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Employee");
            }
            return employee;
        }
        public void LoadEmployeeList()
        {
            lvEmployees.ItemsSource = _context.Employees.ToList();
        }

        private void lvEmployee_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = (Employee)(sender as ListView).SelectedItem;
            if (SelectedItem != null)
            {
                var Gender = SelectedItem.Gender;
                if (Gender.ToLower() == "female")
                {
                    rbFemale.IsChecked = true;
                }
                else
                {
                    rbMale.IsChecked = true;
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = GetEmployeeObject();
                Employee c = GetEmployeeByID(employee.Id);
                if (c != null)
                {
                    _context.Entry<Employee>(c).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{c.Name} updated successful", "Update Employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Edit Employee");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = GetEmployeeObject();
                Employee c = GetEmployeeByID(employee.Id);
                if (c != null)
                {
                    _context.Employees.Remove(c);
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{c.Name} deleted successful", "Delete Employee");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Employee");
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Employee employee = GetEmployeeObject();
                if(employee != null) 
                {
                    employee.Id = 0;
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{employee.Name} inserted successful", "Insert Employee");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Employee");
            }
        }
    }
}
