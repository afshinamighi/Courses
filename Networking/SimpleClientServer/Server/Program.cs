using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace socket_prog
{
    class Server
    {
        static void Main(string[] args)
        {
            // define required variables
            const string ipAdd = "127.0.0.1";
            const int portNum = 32000;
            const int maxBuffSize = 1000;
            byte[] buffer = new byte[maxBuffSize];
            byte[] msg = Encoding.ASCII.GetBytes("From server: Your message delivered\n");
            string data = null;

            // define parameters equired to set up the network
            IPAddress ipAddress = IPAddress.Parse(ipAdd);
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, portNum);

            // establish a listening socket
            Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);

            //bind to the socket
            sock.Bind(localEndpoint);
            // listen with max number of pending incoming requests
            sock.Listen(5);
            Console.WriteLine("\n Waiting for clients..");
            // wait to accept incoming requests
            Socket newSock = sock.Accept();

            // a loop to receive / process / reply
            while (true)
            {
                int b = newSock.Receive(buffer);                    // receive
                data = Encoding.ASCII.GetString(buffer, 0, b);
                                                                    // process
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
                    newSock.Send(msg);                              // reply
                }

            }
            // close the socket
            sock.Close();

        }
    }

}
