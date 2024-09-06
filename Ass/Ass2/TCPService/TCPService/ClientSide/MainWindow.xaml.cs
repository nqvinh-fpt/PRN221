using System;

using System.Collections.Generic;

using System.Windows;

using ClientSide;
namespace Assignment2_PRN221
{
    
    public partial class MainWindow : Window
    {
        /*private readonly UserRepository userRepository;*/
        static Dictionary<string, string> users = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtName.Text;
                string password = txtPassword.Password;
                /*var user = userRepository.GetUsers().FirstOrDefault(u => u.Name == username);*/
                if (username == "vinh" || username == "vinh1" || username == "vinh2")
                {
                    if (password == "12345678")
                    {
                        Login loginWindow = new Login(username);
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

        private void Logout_Click(object sender, RoutedEventArgs e)=>Close();
    }
}