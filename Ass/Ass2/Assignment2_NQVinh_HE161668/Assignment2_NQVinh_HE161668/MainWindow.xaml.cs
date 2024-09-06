﻿using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment2_NQVinh_HE161668
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            users.Add("user1", "password1"); // Sample user credentials
            users.Add("user2", "password2");

            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                int port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    HandleClient(client);

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            byte[] bytes = new byte[1024];
            int i;
            string data;

            // Authenticate user
            bool isAuthenticated = false;
            do
            {
                byte[] authPrompt = Encoding.ASCII.GetBytes("Enter username:");
                stream.Write(authPrompt, 0, authPrompt.Length);
                i = stream.Read(bytes, 0, bytes.Length);
                string username = Encoding.ASCII.GetString(bytes, 0, i).Trim();

                byte[] passPrompt = Encoding.ASCII.GetBytes("Enter password:");
                stream.Write(passPrompt, 0, passPrompt.Length);
                i = stream.Read(bytes, 0, bytes.Length);
                string password = Encoding.ASCII.GetString(bytes, 0, i).Trim();

                if (users.ContainsKey(username) && users[username] == password)
                {
                    isAuthenticated = true;
                    byte[] successMsg = Encoding.ASCII.GetBytes("Authentication successful!");
                    stream.Write(successMsg, 0, successMsg.Length);
                }
                else
                {
                    byte[] errorMsg = Encoding.ASCII.GetBytes("Invalid credentials. Please try again.");
                    stream.Write(errorMsg, 0, errorMsg.Length);
                }
            } while (!isAuthenticated);

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);

                // Process the data sent by the client.
                data = data.ToUpper();

                byte[] msg = Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
            }

            // Shutdown and end connection
            client.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}