
using System;
using System.Windows;

namespace ServerSide
{
    
    public partial class MainWindow : Window
    {
        

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

                if (username == "admin")
                {
                    if (password == "12345678")
                    {

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


        private void Logout_Click(object sender, RoutedEventArgs e)=>Close();
    }
}
