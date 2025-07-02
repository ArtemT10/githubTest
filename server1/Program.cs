using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main()
    {
        
        var ip = IPAddress.Any;
        var port = 12345;
        var server = new TcpListener(ip, port);

        server.Start();
        Console.WriteLine($"server lauft auf {ip}:{port}...");

        while (true)
        {
            using (var client = server.AcceptTcpClient())
            using (var stream = client.GetStream())
            {
                var clientIp = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                Console.WriteLine($"Client ist verbunden: {clientIp}");

                var buffer = new byte[1024];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Bekam message: {message}");

                var response = $"server bekam message: {message}";
                var responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);
            }
        }
    }
}