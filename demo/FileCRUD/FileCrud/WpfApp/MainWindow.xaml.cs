using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
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
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Employee> _lstemployeeDetail;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Employee> LstEmployeeDetail
        {
            get { return _lstemployeeDetail; }
            set
            {
                _lstemployeeDetail = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            LstEmployeeDetail= new ObservableCollection<Employee>();
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
                employee = LstEmployeeDetail.SingleOrDefault(employee => employee.Id== EmployeeID);
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
                    LstEmployeeDetail.Remove(c);
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
                    LstEmployeeDetail.Add(employee);
                    MessageBox.Show($"{employee.Name} inserted successful", "Insert Employee");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Employee");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string jsonData = JsonSerializer.Serialize(LstEmployeeDetail, new JsonSerializerOptions { WriteIndented = true });
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, jsonData);
           
        } 

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string jsonData = File.ReadAllText(openFileDialog.FileName);
                LstEmployeeDetail = JsonSerializer.Deserialize<ObservableCollection<Employee>>(jsonData);
            }

        }
               
    }
}
