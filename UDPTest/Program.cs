using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("(S)erver, (C)lient");
            GameSocket socket;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    GameSocket UdpServer = new Server();
                    break;
                case ConsoleKey.C:
                    GameSocket UdpClient = new Client();
                    break;
                default:
                    return;
            }
            socket.Start();
        }

        private static void ServerRoutine()
        {
            
            UdpServer.Start();
        }

        private static void ClientRoutine()
        {
            
            
        }
    }
}
