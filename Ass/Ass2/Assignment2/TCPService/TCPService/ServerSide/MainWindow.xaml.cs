﻿using ClassLibrary.DataAccess;
using ClassLibrary.Repository;
using MessLibrary.Repository;
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

namespace ServerSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AdminRepository adminRepository;

        public MainWindow()
        {
            InitializeComponent();
            Assignment2Context yourDbContextInstance = new Assignment2Context();
            adminRepository = new AdminRepository(yourDbContextInstance);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtName.Text;
                string password = txtPassword.Password;

                // Retrieve user from the repository based on the entered username
                var user = adminRepository.GetAdmins().FirstOrDefault(u => u.Name == username);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        // Close the current window
                        //this.Close();

                        // Create a new instance of Login window and show it
                        Server loginWindow = new Server(username);
                        loginWindow.Show();

                    }
                    else
                    {
                        throw new Exception("Invalid password!");
                    }
                }

                else
                {
                    throw new Exception("User not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            // Add your signup logic here.
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Đóng tất cả cửa sổ hiện tại
                Application.Current.Windows.Cast<Window>().ToList().ForEach(w => w.Close());

                // Kết thúc ứng dụng
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logout failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
