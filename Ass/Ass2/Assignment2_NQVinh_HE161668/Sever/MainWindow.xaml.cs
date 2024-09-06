using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace TcpServer
{
    public partial class MainWindow : Window
    {
        private TcpListener server;
        private int count = 0;

        public MainWindow()
        {
           
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            string host = "127.0.0.1";
            int port = 13000;

            try
            {
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                server.Start();
                StatusLabel.Text = "Server started. Waiting for connections...";

                Thread listenThread = new Thread(new ThreadStart(ListenForClients));
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting server: " + ex.Message);
            }
        }

        private void ListenForClients()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    count++;
                    Dispatcher.Invoke(() =>
                    {
                        StatusText.Text = $"Number of clients connected: {count}";
                    });

                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error listening for clients: " + ex.Message);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            try
            {
                while ((bytesRead = clientStream.Read(message, 0, 4096)) > 0)
                {
                    string data = Encoding.ASCII.GetString(message, 0, bytesRead);
                    Dispatcher.Invoke(() =>
                    {
                        MessageListBox.Items.Add($"Received: {data}");
                    });

                    byte[] response = Encoding.ASCII.GetBytes(data.ToUpper());
                    clientStream.Write(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling client communication: " + ex.Message);
            }
            finally
            {
                tcpClient.Close();
                count--;
                Dispatcher.Invoke(() =>
                {
                    StatusText.Text = $"Number of clients connected: {count}";
                });
            }
        }

        private void StopServerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                server.Stop();
                StatusText.Text = "Server stopped.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error stopping server: " + ex.Message);
            }
        }
    }
}
