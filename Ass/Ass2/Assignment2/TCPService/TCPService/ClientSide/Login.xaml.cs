using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace ClientSide
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected;
        private string username;
        private List<string> messages = new List<string>();
        private Thread receiveThread;

        // Khai báo logger ở mức class
        private static readonly ILogger logger = new Serilog.LoggerConfiguration()
     .WriteTo.File(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "client_log.txt"), rollingInterval: RollingInterval.Day)
     .CreateLogger();

        public Login(string username)
        {
            InitializeComponent();

            // Store the passed username
            this.username = username;

            // Start the thread for receiving messages
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.Start();
        }

        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    if (isConnected)
                    {
                        byte[] responseBuffer = new byte[256];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);

                        if (bytesRead > 0)
                        {
                            string responseData = Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
                            // Add the received message to the list
                            messages.Add($"Received: {responseData}");
                            // Display the list of messages
                            Application.Current.Dispatcher.Invoke(() => DisplayMessages());

                            // Log the received message using Serilog
                            logger.Information($"Received: {responseData}");
                        }
                    }
                    Thread.Sleep(100); // Adjust sleep duration as needed
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
                UpdateStatus($"Error: {ex.Message}", Brushes.Red);

                // Log the error using Serilog
                logger.Error(ex, "Error occurred");
            }
        }

        private void DisplayMessages()
        {
            // Clear the existing items
            MessageListBox.Items.Clear();

            // Add each message to the ListBox
            foreach (string message in messages)
            {
                MessageListBox.Items.Add(message);
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string server = ServerTextBox.Text;
            int port;

            if (int.TryParse(PortTextBox.Text, out port))
            {
                try
                {
                    client = new TcpClient(server, port);
                    stream = client.GetStream();
                    isConnected = true;
                    UpdateStatus("Connected to the server!", Brushes.Green);

                    // Log the successful connection using Serilog
                    logger.Information("Connected to the server");
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    UpdateStatus($"Error connecting to the server: {ex.Message}", Brushes.Red);

                    // Log the connection error using Serilog
                    logger.Error(ex, "Error connecting to the server");
                }
            }
            else
            {
                UpdateStatus("Invalid port number", Brushes.Red);
            }
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isConnected)
                {
                    UpdateStatus("Not connected to the server", Brushes.Red);
                    return;
                }

                // Use the stored username
                string message = $"Username: {username} - Content: {MessageTextBox.Text} - Time: ({DateTime.Now:T})";
                byte[] data = Encoding.UTF8.GetBytes(message); // Use UTF-8 encoding
                stream.Write(data, 0, data.Length);

                UpdateStatus($"Sent: {message}", Brushes.Black);

                // Log the sent message using Serilog
                logger.Information($"Sent: {message}");
            }
            catch (Exception ex)
            {
                isConnected = false;
                UpdateStatus($"Error: {ex.Message}", Brushes.Red);

                // Log the sending error using Serilog
                logger.Error(ex, "Error sending message");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (isConnected)
            {
                stream.Close();
                client.Close();
                isConnected = false;
                UpdateStatus("Connection closed", Brushes.Orange);

                // Log the connection closure using Serilog
                logger.Information("Connection closed");
            }
        }

        private void UpdateStatus(string message, Brush color)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                StatusTextBlock.Text = message;
                StatusTextBlock.Foreground = color;
            });
        }
    }
}