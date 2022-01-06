using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Client : GameSocket
    {
        UdpClient client;
        IPAddress targetIP;

        public void InitializeClient()
        {
            StartClient();
            SendData();
        }

        private void StartClient()
        {
            client = new UdpClient();
            Console.Write("IP:");
            while(!IPAddress.TryParse(Console.ReadLine(), out targetIP))
            {
                Console.Clear();
                Console.WriteLine("Invalid IP\nIP:");
            }
            Console.Clear();
        }

        private void SendData()
        {
            byte[] data;
            string message;
            do
            {
                message = Console.ReadLine();
                data = Encode(message);
                client.Send(data, data.Length, "localhost", SERVER_PORT);
            } while (message != "stop");           
        }

        ~Client()
        {
            client.Close();
        }
    }
}
