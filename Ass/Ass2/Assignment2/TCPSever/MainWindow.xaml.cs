using System.ComponentModel;
using System.Net;
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
using System.Windows.Controls;

namespace TCPServer
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private TcpListener server;
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        public string ServerStatus
        {
            get { return _serverStatus; }
            set
            {
                _serverStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ServerStatus"));
            }
        }

        private TcpListener _server;
        private Dictionary<string, string> _users;

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _contentLoaded;
        private void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TCPSever;V1.0.0.0;component/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
        }

        private void StartServerButton_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(StartServer);
        }

        private void StartServer(object state)
        {
            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                int port = 13000;

                _server = new TcpListener(localAddr, port);
                _server.Start();

                ServerStatus = "Server started";

                while (true)
                {
                    TcpClient client = _server.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(HandleClient, client);
                }
            }
            catch (Exception ex)
            {
                ServerStatus = "Error: " + ex.Message;
            }
        }

        private void HandleClient(object client)
        {
            using (TcpClient tcpClient = (TcpClient)client)
            using (NetworkStream stream = tcpClient.GetStream())
            {
                byte[] bytes = new byte[1024];
                int bytesRead;

                bool isAuthenticated = false;

                while (!isAuthenticated)
                {
                    // Send authentication request
                    SendMessage(stream, "Enter username:");
                    bytesRead = stream.Read(bytes, 0, bytes.Length);
                    string username = Encoding.ASCII.GetString(bytes, 0, bytesRead).Trim();

                    SendMessage(stream, "Enter password:");
                    bytesRead = stream.Read(bytes, 0, bytes.Length);
                    string password = Encoding.ASCII.GetString(bytes, 0, bytesRead).Trim();

                    if (_users.ContainsKey(username) && _users[username] == password)
                    {
                        SendMessage(stream, "Authentication successful!");
                        isAuthenticated = true;
                    }
                    else
                    {
                        SendMessage(stream, "Invalid credentials. Please try again.");
                    }
                }

                // Handle other communication after authentication
                while ((bytesRead = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    data = data.ToUpper();

                    byte[] response = Encoding.ASCII.GetBytes(data);
                    stream.Write(response, 0, response.Length);
                }
            }
        }

        private void StopServerButton_Click(object sender, RoutedEventArgs e)
        {
            _server.Stop();
            ServerStatus = "Server stopped";
        }

        private void SendMessage(NetworkStream stream, string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}