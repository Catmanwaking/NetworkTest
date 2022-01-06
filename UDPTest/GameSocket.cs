using System.Text;
using System.Net.Sockets;
using System.Net;

namespace UDPTest
{
    class GameSocket
    {
        public const int SERVER_PORT = 2345;
        public const int MAX_ROOM_SIZE = 8;

        protected byte[] Encode(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        protected string Decode(byte[] data, int length = 0)
        {
            length = length == 0 ? data.Length : length;
            return Encoding.UTF8.GetString(data, 0, length);
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
    }
}
