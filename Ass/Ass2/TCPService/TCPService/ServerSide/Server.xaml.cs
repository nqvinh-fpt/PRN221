using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
using Microsoft.Win32;
using System.IO;
using ClassLibrary;
using Serilog.Formatting.Compact;
using Serilog;

namespace ServerSide
{
    /// <summary>
    /// Interaction logic for Server.xaml
    /// </summary>
    public partial class Server : Window
    {
        private TcpListener tcpListener;
        private Thread listenerThread;
        private NetworkStream stream;
        private bool isConnected;
        private string username;
        private List<string> messages = new List<string>();
        private List<TcpClient> connectedClients = new List<TcpClient>();
        private EncryptionHelper encryptionHelper = new EncryptionHelper();
        private static readonly ILogger logger = new Serilog.LoggerConfiguration()
    .WriteTo.File(new RenderedCompactJsonFormatter(), System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "client_log.xml"))
    .CreateLogger();
        public Server(string username)
        {
            InitializeComponent();

            
            this.username = username;

          
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
                    tcpListener = new TcpListener(IPAddress.Parse(server), port);
                    tcpListener.Start();

                    UpdateStatus($"Server started. On port {port}", Brushes.Green);

                    listenerThread = new Thread(new ThreadStart(ListenForClients));
                    listenerThread.Start();
                }
                catch (Exception ex)
                {
                    UpdateStatus($"Error starting server: {ex.Message}", Brushes.Red);
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
                if (connectedClients.Count > 0)
                {
                    string messageText = $"User: {MessageTextBox.Text} - Time: {DateTime.Now:T}";
                    byte[] data = Encoding.UTF8.GetBytes(messageText);

                    foreach (var client in connectedClients)
                    {
                        NetworkStream clientStream = client.GetStream();
                        clientStream.Write(data, 0, data.Length);
                    }

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageListBox.Items.Add($"Sent to all clients: {messageText}");
                    });
                }
                else
                {
                    UpdateStatus("No clients connected", Brushes.Red);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private void UpdateStatus(string message, Brush color)
        {
            StatusTextBlock.Text = message;
            StatusTextBlock.Foreground = color;
        }

        private void ListenForClients()
        {
            try
            {
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    connectedClients.Add(client);

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] encryptedMessage = new byte[4096];
            int bytesRead;

            try
            {
                while (true)
                {
                    bytesRead = clientStream.Read(encryptedMessage, 0, 4096);
                    if (bytesRead == 0)
                        break;

                    // Decrypt the received message using the EncryptionHelper
                    string receivedMessage = encryptionHelper.Decrypt(encryptedMessage.Take(bytesRead).ToArray());
                    Console.WriteLine($"Decrypted Received: {receivedMessage}");

                    // Process the decrypted received message (you can implement your logic here)

                    // Encrypt the response message before sending it back
                    string responseMessage = $"Server received: {receivedMessage}";
                    byte[] encryptedResponse = encryptionHelper.Encrypt(responseMessage);
                    clientStream.Write(encryptedResponse, 0, encryptedResponse.Length);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageListBox.Items.Add($"Received from client: {receivedMessage}");
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                clientStream.Close();
                tcpClient.Close();
                connectedClients.Remove(tcpClient);
                Console.WriteLine("Client disconnected");
            }
        }
    }
}