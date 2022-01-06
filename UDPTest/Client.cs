using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Client : GameSocket
    {
        UdpClient client;
        IPEndPoint endPoint;

        public void InitializeClient()
        {
            StartClient();
            SendData();
        }

        private void StartClient()
        {
            client = new UdpClient();
            IPAddress targetIP;
            Console.Write("IP:");
            while (!IPAddress.TryParse(Console.ReadLine(), out targetIP))
            {
                Console.Clear();
                Console.WriteLine("Invalid IP\nIP:");
            }
            Console.Clear();
            endPoint = new IPEndPoint(targetIP, SERVER_PORT);
        }

        private void SendData()
        {
            byte[] data;
            string message;
            do
            {
                message = Console.ReadLine();
                data = Encode(message);
                client.Send(data, data.Length, endPoint);
            } while (message != "stop");
        }

        ~Client()
        {
            client.Close();
        }
    }
}
