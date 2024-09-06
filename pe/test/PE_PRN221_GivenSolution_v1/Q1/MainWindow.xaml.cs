using Q1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_TrialContext _context;
        public MainWindow(PRN221_TrialContext context)
        {

            InitializeComponent();
            _context = context;
            LoadEmployeeList();
        }

        private void LoadEmployeeList()
        {
            dgvData.ItemsSource = _context.Employees.ToList();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtEmployeeId.Text= string.Empty;
            txtEmployeeName.Text= string.Empty;
            rbtnMale.IsChecked = true;
            rbtnFemale.IsChecked = false;
            sldateDOB.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtIDNumber.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Employee employee = GetRoomObject();
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    LoadEmployeeList();
                    MessageBox.Show($"{employee.Name} inserted successful", "Insert Room");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add room");
            }

        }
        private Employee GetRoomObject()
        {
            string checkStatus = "notset";
            if (rbtnMale.IsChecked == true)
            {
                checkStatus = "Male";
            }
            else if (rbtnFemale.IsChecked == true)
            {
                checkStatus = "Female";
            }
            Employee employee = null;
            try
            {
                employee = new Employee()
                {
                    Name = txtEmployeeName.Text,
                    Gender = checkStatus,
                    Dob = DateTime.Parse(sldateDOB.Text.ToString()),
                    Phone = txtPhone.Text,
                    Idnumber = txtIDNumber.Text,
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Employee");
            }
            return employee;
        }

    }
}
