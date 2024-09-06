﻿using System;
using System.IO;
using System.Net;

class Program
{
    static void Main(string[] ares)
    {

        // Create a request for the URL.
        WebRequest request = WebRequest.Create("https://fpt.edu.vn/");
        // Tf required by the server, set the credentials.
        request.Credentials = CredentialCache.DefaultCredentials;
        // Get the response.
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        // Display the status.
        Console.WriteLine("Status: " + response.StatusDescription);
        Console.WriteLine(new string('*', 50));
        // Get the stream containing content returned by the server.
        Stream dataStream = response.GetResponseStream();
        // Open the stream using a StreamReader for easy access.
        StreamReader reader = new StreamReader(dataStream);
        // Read the content.
        string responseFromServer = reader.ReadToEnd();
        // Display the content.
        Console.WriteLine(responseFromServer);
        Console.WriteLine(new string('*', 50));
        // Cleanup the streams and the response.
        reader.Close();
        dataStream.Close();
        response.Close();
    }
}