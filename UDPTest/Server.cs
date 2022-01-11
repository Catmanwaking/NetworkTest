using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Server : GameSocket
    {
        private IPEndPoint[] clients = new IPEndPoint[MAX_ROOM_SIZE];
        private int currentClientCount = 0;

        public override void Start()
        {
            RepeatListen();
        }

        private void RepeatListen()
        {
            string message;
            do
            {
                message = RecieveMessage();
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
                    message = $"message from {message} acknowledged, IP temporarily stored for communication, you are client {currentClientCount}";
                    Console.WriteLine(message);
                    byte[] data = Encode(message);
                    IPEndPoint clientEndPoint = new IPEndPoint(sender, SERVER_PORT);
                    clients[currentClientCount++] = clientEndPoint;
                    server.Send(data, data.Length, clientEndPoint);
                }                
            }
        }
    }
}
