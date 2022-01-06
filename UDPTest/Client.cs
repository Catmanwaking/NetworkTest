using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Client : GameSocket
    {
        UdpClient client;
        IPEndPoint serverEndPoint;
        IPEndPoint localEndPoint;        

        public void InitializeClient()
        {
            StartClient();
            RepeatSendData();
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
            serverEndPoint = new IPEndPoint(targetIP, SERVER_PORT);

            WaitForAcknowledge();
        }

        private void WaitForAcknowledge()
        {
            localEndPoint = new IPEndPoint(GetLocalIPAddress(), SERVER_PORT);
            SendString(localEndPoint.Address.ToString());

            byte[] data = client.Receive(ref localEndPoint);
            Console.WriteLine(Decode(data));
        }

        private void RepeatSendData()
        {
            string message;
            do
            {
                message = Console.ReadLine();
                SendString(message);
            } while (message != "stop");
        }

        private void SendString(string message)
        {
            byte[] data = Encode(message); //watch out for message length
            client.Send(data, data.Length, serverEndPoint);
        }

        ~Client()
        {
            client.Close();
        }
    }
}
