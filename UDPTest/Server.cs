using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Server : GameSocket
    {
        UdpClient server;
        IPEndPoint endPoint;        

        public void InitializeServer()
        {
            StartServer();
            Listen();
        }

        private void StartServer()
        {
            server = new UdpClient(SERVER_PORT);
            endPoint = new IPEndPoint(GetLocalIPAddress(), SERVER_PORT);
            Console.WriteLine(endPoint.Address.ToString());
        }

        private void Listen()
        {
            byte[] data;
            string message;
            do
            {
                data = server.Receive(ref endPoint);
                message = Decode(data);
                Console.WriteLine(message);
            } while (message != "stop");
        }

        private IPAddress GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }

        ~Server()
        {
            server.Close();
        }
    }
}
