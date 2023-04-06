using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 8001);
            server.Start(100);
            TcpClient client= server.AcceptTcpClient();
            SendRandom(client);
        }
        static Random r = new Random();
        static int start=1;
        static int end =10000;
        public static void SendRandom(TcpClient client)
        {
            while (true)
            {
                
            NetworkStream stream = client.GetStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine(r.Next(start, end).ToString());
            sw.Flush();
            Thread.Sleep(TimeSpan.FromSeconds(10));
            }
        }
    }
}
