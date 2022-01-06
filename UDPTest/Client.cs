using System;
using System.Net;
using System.Net.Sockets;

namespace UDPTest
{
    class Client : GameSocket
    {
        IPEndPoint serverEndPoint;     

        public Client() : base()
        {

        }

        public override void Start()
        {
            GetTargetIP();
            WaitForAcknowledge();
            RepeatSendData();
        }

        private void GetTargetIP()
        {
            IPAddress targetIP;
            Console.Write("IP:");
            while (!IPAddress.TryParse(Console.ReadLine(), out targetIP))
            {
                Console.Clear();
                Console.WriteLine("Invalid IP\nIP:");
            }
            Console.Clear();
            serverEndPoint = new IPEndPoint(targetIP, SERVER_PORT);            
        }

        private void WaitForAcknowledge()
        {
            SendMessage(localEndPoint.Address.ToString(), serverEndPoint);
            Console.WriteLine(RecieveMessage());
        }

        private void RepeatSendData()
        {
            string message;
            do
            {
                message = Console.ReadLine();
                SendMessage(message, serverEndPoint);
            } while (message != "stop");
        }
    }
}
