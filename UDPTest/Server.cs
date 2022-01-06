using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Server : GameSocket
    {
        private UdpClient server;
        private IPEndPoint localEndPoint;
        private IPEndPoint[] clients = new IPEndPoint[MAX_ROOM_SIZE];
        private int currentClientCount;

        public void InitializeServer()
        {
            StartServer();
            RepeatListen();
        }

        private void StartServer()
        {
            server = new UdpClient(SERVER_PORT);
            localEndPoint = new IPEndPoint(GetLocalIPAddress(), SERVER_PORT);
            Console.WriteLine(localEndPoint.Address.ToString());
        }

        private void RepeatListen()
        {
            byte[] data;
            string message;
            do
            {
                data = server.Receive(ref localEndPoint);
                message = Decode(data);
                Console.WriteLine(message);

                CheckIncomingClient(message);                

            } while (message != "stop");
        }

        private void CheckIncomingClient(string message)
        {
            if (IPAddress.TryParse(message, out IPAddress sender)) //this can be heavily improved by using the first byte of the data
            {
                if(currentClientCount + 1 >= MAX_ROOM_SIZE)
                {
                    byte[] data = Encode($"room is full");
                    IPEndPoint clientEndPoint = new IPEndPoint(sender, SERVER_PORT);
                    server.Send(data, data.Length, clientEndPoint);
                }
                else
                {
                    byte[] data = Encode($"message from {message} acknowledged, IP temporarily stored for communication, you are client {currentClientCount}");
                    IPEndPoint clientEndPoint = new IPEndPoint(sender, SERVER_PORT);
                    clients[currentClientCount++] = clientEndPoint;
                    server.Send(data, data.Length, clientEndPoint);
                }
                
            }
        }

        ~Server()
        {
            server.Close();
        }
    }
}
