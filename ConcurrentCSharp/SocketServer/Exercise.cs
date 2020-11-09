using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Exercise
{
    public class ClientInfo
    {
        public string studentnr { get; set; }
        public string classname { get; set; }
        public int clientid { get; set; }
        public string teamname { get; set; }
        public string ip { get; set; }
        public string secret { get; set; }
        public string status { get; set; }
    }

    public class Message
    {
        public const string welcome = "WELCOME";
        public const string cmd_os = "[A command to execute will appear here]";
        public const string cmd_close = "Closing current connection";
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

        public void prepareServer()
        {
            byte[] bytes = new Byte[bufferSize];
            String data = null;
            int numByte = 0;
            string replyMsg = "";
            bool stop;

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
                    this.sendReply(connection, Message.welcome);

                    stop = false;
                    while (!stop)
                    {
                        numByte = connection.Receive(bytes);
                        data = Encoding.ASCII.GetString(bytes, 0, numByte);
                        replyMsg = processMessage(data);
                        if (replyMsg.Equals(Message.cmd_close))
                        {
                            stop = true;
                            break;
                        }
                        else
                            this.sendReply(connection, replyMsg);
                    }

                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
        public void handleClient(Socket con)
        {
        }
        public string processMessage(String msg)
        {
            Thread.Sleep(processingTime);
            Console.WriteLine("[Server] received from the client -> {0} ", msg);
            string replyMsg = "";

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
                        //todo: a prper default action
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("[Server] processMessage {0}", e.Message);
            }

            return replyMsg;
        }
        public void sendReply(Socket connection, string msg)
        {
            byte[] encodedMsg = Encoding.ASCII.GetBytes(msg);
            connection.Send(encodedMsg);
        }
        public void exportResults()
        {
            if (stopCond)
            {
                this.printClients();
            }
        }
        public void printClients()
        {
            string delimiter = " , ";
            Console.Out.WriteLine("[Server] This is the list of clients communicated");
            foreach (ClientInfo c in clients)
            {
                Console.WriteLine(c.classname + delimiter + c.studentnr + delimiter + c.clientid.ToString());
            }
            Console.Out.WriteLine("[Server] Number of handled clients: {0}", clients.Count);

            clients.Clear();
            stopCond = false;

        }
    }


    public class ConcurrentServer
    {
        // todo: implement this class

    }

    public class ServerSimulator
    {
        public static void sequentialRun()
        {
            Console.Out.WriteLine("[Server] A sample server, sequential version ...");
            SequentialSimpleServer server = new SequentialSimpleServer();
            server.prepareServer();
        }
        public static void concurrentRun()
        {
            // todo: After finishing the concurrent version of the server, implement this method to start the concurrent server
        }
    }
}
