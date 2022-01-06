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
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    break;
                case ConsoleKey.C:
                    break;
                default:
                    return;
            }
            
        }

        private static void ServerRoutine()
        {
            Server UdpServer = new Server();
            UdpServer.InitializeServer();
        }

        private static void ClientRoutine()
        {
            Client UdpClient = new Client();
            UdpClient.InitializeServer();
        }
    }
}
