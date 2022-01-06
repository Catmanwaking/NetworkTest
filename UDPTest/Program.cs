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
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.S:
                    ServerRoutine();
                    break;
                case ConsoleKey.C:
                    ClientRoutine();
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
            UdpClient.InitializeClient();
        }
    }
}
