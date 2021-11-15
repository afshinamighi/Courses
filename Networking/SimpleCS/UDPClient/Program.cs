using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 32000;
            int maxBuffSize = 1000;
            byte[] buffer = new byte[maxBuffSize];
            byte[] msg = Encoding.ASCII.GetBytes("Hello from client\n");
            Socket sock = null;

            IPAddress ipAddress = IPAddress.Parse(ip);

            IPEndPoint ServerEndpoint = new IPEndPoint(ipAddress, port);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0); // port number 0 means: any port number
            EndPoint remoteEP = (EndPoint)sender;

            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                sock.SendTo(msg, msg.Length, SocketFlags.None, ServerEndpoint);
                int b = sock.ReceiveFrom(buffer, ref remoteEP);
                string data = Encoding.ASCII.GetString(buffer, 0, b);
                Console.WriteLine("A message received from " + remoteEP.ToString() + " " + data);
                Console.WriteLine("Server said" + data);
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
