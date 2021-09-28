using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace socket_prog
{
    class Client
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[1000];
            byte[] msg = new byte[1000];
            string data = null;


            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            IPEndPoint serverEndpoint = new IPEndPoint(ipAddress, 32000);

            ConsoleKeyInfo key;


            Socket sock = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(serverEndpoint);

            while (true)
            {
                Console.WriteLine("\nEnter a message to send to the server");
                data = Console.ReadLine();
                if (data.Length != 0)
                {

                    msg = Encoding.ASCII.GetBytes(data);
                    sock.Send(msg);
                    int b = sock.Receive(buffer);
                    data = Encoding.ASCII.GetString(buffer, 0, b);

                    Console.WriteLine("" + data);
                    data = null;
                }

                Console.WriteLine("\n<< Continue 'y' , Exit 'e'>>\n");
                key = Console.ReadKey();
                if (key.KeyChar == 'e')
                {
                    sock.Send(Encoding.ASCII.GetBytes("Closed"));
                    Console.WriteLine("\nExiting.. Press any key to continue");
                    key = Console.ReadKey();
                    sock.Close();
                    break;
                }

            }
        }
    }

}
