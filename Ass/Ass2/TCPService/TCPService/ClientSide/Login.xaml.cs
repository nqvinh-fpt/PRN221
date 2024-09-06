using Serilog;
using Serilog.Formatting.Compact;
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
    /// 
    public partial class Login : Window
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected;
        private string username;
        private List<string> messages = new List<string>();
        private Thread receiveThread;
        private static readonly ILogger logger = new Serilog.LoggerConfiguration()
    .WriteTo.File(new RenderedCompactJsonFormatter(), System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "client_log.xml"))
    .CreateLogger();

        public Login(string username)
        {
            InitializeComponent();
            this.username = username;
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
                            
                            messages.Add($"Received: {responseData}");
                            
                            Application.Current.Dispatcher.Invoke(() => DisplayMessages());

                            
                            logger.Information($"Received: {responseData}");
                        }
                    }
                    Thread.Sleep(100); 
                }
            }
            catch (Exception ex)
            {
                isConnected = false;
                UpdateStatus($"Error: {ex.Message}", Brushes.Red);

                
                logger.Error(ex, "Error occurred");
            }
        }

        private void DisplayMessages()
        {
            
            MessageListBox.Items.Clear();

            
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
                    UpdateStatus("Connected server!", Brushes.Green);

                    
                    logger.Information("Connected to the server");
                }
                catch (Exception ex)
                {
                    isConnected = false;
                    UpdateStatus($"Error connecting  server: {ex.Message}", Brushes.Red);

                    
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

                
                string message = $"Username: {username} - Content: {MessageTextBox.Text} - Time: ({DateTime.Now:T})";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                UpdateStatus($"Sent: {message}", Brushes.Black);

                logger.Information($"Sent: {message}");
            }
            catch (Exception ex)
            {
                isConnected = false;
                UpdateStatus($"Error: {ex.Message}", Brushes.Red);

                
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