using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    class Server
    {
        static void Main(string[] args)
        {

            string ip = "127.0.0.1";
            int port = 32000;
            int maxBuffSize = 1000;
            int MsgCounter = 0;
            byte[] buffer = new byte[maxBuffSize];
            byte[] msg = Encoding.ASCII.GetBytes("From server: Your message delivered\n");
            string data = null;
            Socket sock = null;

            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, port);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); // port number 0 means: any port number
            EndPoint remoteEP = (EndPoint)sender;

            try
            {
                sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram, ProtocolType.Udp);
                sock.Bind(localEndpoint);
                while (MsgCounter < 10)
                {
                    Console.WriteLine("\n Waiting for the next client message..");
                    int b = sock.ReceiveFrom(buffer, ref remoteEP);
                    data = Encoding.ASCII.GetString(buffer, 0, b);
                    Console.WriteLine("A message received from "+remoteEP.ToString()+ " " + data);
                    sock.SendTo(msg, msg.Length, SocketFlags.None, remoteEP);
                    MsgCounter++;
                }
            }
            catch
            {
                Console.WriteLine("\n Socket Error. Terminating");
            }
            finally
            {
                sock.Close();
            }
        }
    }
}
