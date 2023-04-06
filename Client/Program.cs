using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Loopback,8002);
            TcpClient client = new TcpClient(point);
            IPEndPoint server_point = new IPEndPoint(IPAddress.Loopback,8001);

            client.Connect(server_point);
            while (true)
            {
                StreamReader sr = new StreamReader(client.GetStream());
                Console.WriteLine("Server: "+sr.ReadLine());

            }
        }
    }
}
