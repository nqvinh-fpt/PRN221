using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static TcpListener tcpListener;
    static Socket clientSocket;
    static string serverIP = "127.0.0.1";
    static void Main()
    {
        Console.WriteLine("Server is running...");
        StartServer();
    }

    static void StartServer()
    {
        tcpListener = new TcpListener(IPAddress.Parse(serverIP), 8888);
        
        tcpListener.Start();

        Console.WriteLine($"Server started at {serverIP}. Waiting for connections...");
        
        clientSocket = tcpListener.AcceptSocket();
        Console.WriteLine("Client connected.");

        HandleClient();
    }

    static void HandleClient()
    {
        // ... (rest of the code remains unchanged)

        // Restart the server to listen for the next connection
        StartServer();
    }

    static string GetLocalIPAddress()
    {
        var hostName = Dns.GetHostName();
        var entry = Dns.GetHostEntry(hostName);
        foreach (var ipAddress in entry.AddressList)
        {
            if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                return ipAddress.ToString();
            }
        }
        return "N/A";
    }
}
