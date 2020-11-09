using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Exercise
{
    public class Message
    {
        public const string welcome = "WELCOME";
        public const string cmd_os = "[A command to execute will appear here]";
        public const string cmd_close = "Closing server";
    }

    public class SequentialSimpleServer
    {
        public Socket listener;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public readonly int portNumber = 11111;

        public String results = "";

        private Boolean stopCond = false;
        private int processingTime = 1000;
        private int listeningQueueSize = 5;
        public readonly int bufferSize = 1024;
        private int numOfClients = 0;

        public void prepareServer()
        {

            try
            {
                Console.WriteLine("[Server] is ready to start ...");
                // Establish the local endpoint
                localEndPoint = new IPEndPoint(ipAddress, portNumber);
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Console.Out.WriteLine("[Server] A socket is established ...");
                // associate a network address to the Server Socket. All clients must know this address
                listener.Bind(localEndPoint);
                // This is a non-blocking listen with max number of pending requests
                listener.Listen(listeningQueueSize);
                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    // Suspend while waiting for incoming connection 
                    Socket connection = listener.Accept();
                    this.numOfClients++;
                    this.handleClient(connection);
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
        public void handleClient(Socket con)
        {
            String data = null;
            int numByte = 0;
            byte[] bytes = new Byte[bufferSize];

            this.sendReply(con, Message.welcome);

            numByte = con.Receive(bytes);
            data = Encoding.ASCII.GetString(bytes, 0, numByte);
            processMessage(data);
        }
        public void processMessage(String msg)
        {
            Thread.Sleep(processingTime);
            Console.WriteLine("[Server] received from the client -> {0} ", msg);

            try
            {
                switch (msg)
                {
                    case Message.cmd_os:
                        //todo: proper action according to the os command
                        break;
                    case Message.cmd_close:
                        //todo: proper action according to the closing command
                        break;
                    default:
                        //todo: a proper default action
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("[Server] processMessage {0}", e.Message);
            }
        }
        public void sendReply(Socket connection, string msg)
        {
            byte[] encodedMsg = Encoding.ASCII.GetBytes(msg);
            connection.Send(encodedMsg);
        }
    }

    public class ServerSimulator
    {
        public static void sequentialRun()
        {
            Console.Out.WriteLine("[Server] A sample server, sequential version ...");
            SequentialSimpleServer server = new SequentialSimpleServer();
            server.prepareServer();
        }
    }
}