using System.Text;
using System.Net.Sockets;

namespace UDPTest
{
    class GameSocket
    {
        public const int SERVER_PORT = 2345;

        protected byte[] Encode(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        protected string Decode(byte[] data, int length = 0)
        {
            length = length == 0 ? data.Length : length;
            return Encoding.UTF8.GetString(data, 0, length);
        }
    }
}
