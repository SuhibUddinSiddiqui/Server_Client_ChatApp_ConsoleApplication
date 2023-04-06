using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Server;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
       TcpListener serversocket = new TcpListener(IPAddress.Parse("192.168.1.181"),8888);
            TcpClient clientsocket = default(TcpClient);
        ServerSocket.Start();
            

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clientsocket.Connect(ipaddress, 8888);
            label1.Text = "Client socket program-server connected";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server.Data d = new Server.Data();
            d.name = textBox1.Text;
            d.msg = textBox2.Text;
            NetworkStream ns = clientsocket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ns, d);
            ns.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Server.Data d = new Server.Data();
            d.name = textBox1.Text;
            d.msg = textBox2.Text;
            NetworkStream ns = clientsocket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ns, d);
            ns.Close();
        }
    }
}
