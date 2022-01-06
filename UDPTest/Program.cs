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
                    socket = new Server();
                    break;
                case ConsoleKey.C:
                    socket = new Client();
                    break;
                default:
                    return;
            }
            socket.Start();
        }
    }
}
