using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main()
    {
        using (var client = new TcpClient("localhost", 12344))
        using (var stream = client.GetStream())
        {

            var message = "Hallo 'Dringende Änerungen von githubTest#3', server!";
            var data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);


            var buffer = new byte[1024];
            var bytesRead = stream.Read(buffer, 0, buffer.Length);
            Console.WriteLine($"Antwort von server: {Encoding.UTF8.GetString(buffer, 0, bytesRead)}");
        }

        Console.ReadLine();
    }
}