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

namespace TCPClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();
        public MainWindow()
        {
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
        try
        {
            // Connect to a remote device.
            int port = 13000;
            TcpClient client = new TcpClient("127.0.0.1", port);

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Authenticate user
            string response = GetMessage(stream);
            Console.WriteLine(response);

            while (response != "Authentication successful!")
            {
                // If authentication failed, exit
                if (response == "Invalid credentials. Please try again.")
                {
                    stream.Close();
                    client.Close();
                    return;
                }

                string username = Console.ReadLine();
                SendMessage(stream, username);

                string password = Console.ReadLine();
                SendMessage(stream, password);

                response = GetMessage(stream);
                Console.WriteLine(response);
            }

            // If authentication successful, continue with sending messages
            while (true)
            {
                    
                Console.Write("Enter message: ");
                string message = Console.ReadLine();

                // Send the message to the server.
                SendMessage(stream, message);

                // Receive the response from the server.
                response = GetMessage(stream);
                Console.WriteLine("Server response: {0}", response);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: {0}", ex);
        }

        Console.Read();
    }

    static void SendMessage(NetworkStream stream, string message)
    {
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }

    static string GetMessage(NetworkStream stream)
    {
        byte[] data = new byte[1024];
        int bytes = stream.Read(data, 0, data.Length);
        return Encoding.ASCII.GetString(data, 0, bytes);
    }
}
}
