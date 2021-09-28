using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SoekctServer
{
    class Server
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 32000;
            int maxBuffSize = 1000;

            byte[] buffer = new byte[maxBuffSize];
            byte[] msg = Encoding.ASCII.GetBytes("From server: Your message delivered\n");
            string data = null;


            IPAddress ipAddress = IPAddress.Parse(ip);

            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, port);


            Socket sock = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);


            sock.Bind(localEndpoint);
            sock.Listen(5);
            Console.WriteLine("\n Waiting for clients..");
            Socket newSock = sock.Accept();

            while (true)
            {
                int b = newSock.Receive(buffer);
                data = Encoding.ASCII.GetString(buffer, 0, b);

                if (data == "Closed")
                {
                    newSock.Close();
                    Console.WriteLine("Closing the socket..");
                    break;
                }
                else
                {
                    Console.WriteLine("" + data);
                    data = null;
                    newSock.Send(msg);
                }

            }
            sock.Close();

        }
    }

}
