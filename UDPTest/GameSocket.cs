using System.Text;
using System.Net.Sockets;
using System.Net;
using System;

namespace UDPTest
{
    public abstract class GameSocket
    {
        public const int SERVER_PORT = 4000; //borrowing Diablo's server port
        public const int MAX_ROOM_SIZE = 8;

        protected UdpClient server;
        protected IPEndPoint localEndPoint;

        public GameSocket()
        {
            server = new UdpClient(SERVER_PORT);
            localEndPoint = new IPEndPoint(GetLocalIPAddress(), SERVER_PORT);
            //GetOwnIPManual();
            //localEndPoint = new IPEndPoint(IPAddress.Any, SERVER_PORT);
            Console.WriteLine(localEndPoint.Address.ToString());
        }

        ~GameSocket()
        {
            server.Close();
        }

        protected byte[] Encode(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        protected string Decode(byte[] data, int length = 0)
        {
            length = length == 0 ? data.Length : length;
            return Encoding.UTF8.GetString(data, 0, length);
        }

        protected string RecieveMessage()
        {
            byte[] data = server.Receive(ref localEndPoint);
            return Decode(data);
        }

        protected void SendMessage(string message, IPEndPoint serverEndPoint)
        {
            byte[] data = Encode(message); //watch out for message length
            server.Send(data, data.Length, serverEndPoint);
        }

        protected IPAddress GetLocalIPAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }

        private void GetOwnIPManual()
        {
            IPAddress targetIP;
            Console.Write("IP:");
            while (!IPAddress.TryParse(Console.ReadLine(), out targetIP))
            {
                Console.Clear();
                Console.WriteLine("Invalid IP\nIP:");
            }
            Console.Clear();
            localEndPoint = new IPEndPoint(targetIP/*IPAddress.Any*/, SERVER_PORT);
        }

        public abstract void Start();
    }
}
