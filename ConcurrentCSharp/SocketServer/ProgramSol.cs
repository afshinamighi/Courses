using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace SocketServerSol
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
        public const string stopCommunication = "COMC-STOP";
        public const string statusEnd = "STAT-STOP";
        public const string secret = "SECRET";
    }

    public class SequentialServer
    {
        public Socket listener;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public readonly int portNumber = 11111;

        public String results = "";
        public LinkedList<ClientInfo> clients = new LinkedList<ClientInfo>();

        private Boolean stopCond = false;
        private int processingTime = 1000;
        private int listeningQueueSize = 200;

        public void prepareServer()
        {
            try
            {
                Console.WriteLine("[Server] is ready to start ...");
                // Establish the local endpoint
                localEndPoint = new IPEndPoint(ipAddress, portNumber);
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Console.Out.WriteLine("[Server] A socket is established ...");
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
        public void startServer()
        {
            try
            {
                // associate a network address to the Server Socket. All clients must know this address
                listener.Bind(localEndPoint);
                // This is a non-blocking listen with max number of pending requests
                listener.Listen(listeningQueueSize);
                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    // Suspend while waiting for incoming connection Using  
                    Socket connection = listener.Accept();
                    this.handleClient(connection);
                }
            }
            catch (Exception e)
            {
                listener.Shutdown(SocketShutdown.Both);
                Console.WriteLine("[Server] Listening socket:{0}", e.ToString());
            }
        }
        public void handleClient(Socket con)
        {
            // Data buffer 
            byte[] bytes = new Byte[1024];
            String data = null;
            int numByte = 0;
            string replyMsg = "";

            this.sendReply(con, Message.welcome);

            Boolean stop = false;

            while (!stop)
            {
                numByte = con.Receive(bytes);
                data = Encoding.ASCII.GetString(bytes, 0, numByte);
                replyMsg = processMessage(data);
                if (replyMsg.Equals(Message.stopCommunication))
                {
                    stop = true;
                    break;
                }
                else
                    this.sendReply(con, replyMsg);
            }
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
                    case Message.stopCommunication:
                        replyMsg = Message.stopCommunication;
                        break;
                    default:
                        ClientInfo c = JsonSerializer.Deserialize<ClientInfo>(msg.ToString());
                        clients.AddLast(c);
                        if(c.clientid == -1)
                        {
                            stopCond = true;
                            exportResults();
                        }
                        c.secret = c.studentnr + Message.secret;
                        c.status = Message.statusEnd;
                        replyMsg = JsonSerializer.Serialize<ClientInfo>(c);
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
            // Send a message to Client  
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
        public Socket listener;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public readonly int portNumber = 11111;

        public String results = "";
        public LinkedList<ClientInfo> clients = new LinkedList<ClientInfo>();

        private Boolean stopCond = false;
        private int processingTime = 1000;
        private int listeningQueueSize = 200;

        // specific for concurrent server
        private Object mutex = new object();

        public void prepareServer()
        {
            try
            {
                Console.WriteLine("[Server] is ready to start ...");
                // Establish the local endpoint
                localEndPoint = new IPEndPoint(ipAddress, portNumber);
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Console.Out.WriteLine("[Server] A socket is established ...");
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
        public void startServer()
        {
            try
            {
                // associate a network address to the Server Socket. All clients must know this address
                listener.Bind(localEndPoint);
                // This is a non-blocking listen with max number of pending requests
                listener.Listen(listeningQueueSize);
                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    // Suspend while waiting for incoming connection Using  
                    Socket clientSocket = listener.Accept();
                    Thread t = new Thread(() => handleClient(clientSocket));
                    //connections.AddLast(t);
                    t.Start();
                }
            }
            catch (Exception e)
            {
                listener.Shutdown(SocketShutdown.Both);
                Console.WriteLine("[Server] Listening socket:{0}", e.ToString());
            }
        }
        public void handleClient(Socket con)
        {
            // Data buffer 
            byte[] bytes = new Byte[1024];
            String data = null;
            int numByte = 0;
            string replyMsg = "";

            this.sendReply(con, Message.welcome);

            Boolean stop = false;

            try
            {
                while (!stop)
                {
                    numByte = con.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, numByte);
                    replyMsg = processMessage(data);
                    if (replyMsg.Equals(Message.stopCommunication))
                    {
                        stop = true;
                        break;
                    }
                    else
                        this.sendReply(con, replyMsg);
                }
            }catch(Exception e)
            {
                Console.WriteLine("[Server] [Exception] {0}", e.Message);
            }
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
                    case Message.stopCommunication:
                        replyMsg = Message.stopCommunication;
                        break;
                    default:
                        ClientInfo c = JsonSerializer.Deserialize<ClientInfo>(msg.ToString());
                        lock (mutex)
                        {
                            clients.AddLast(c);
                            if (c.clientid == -1)
                            {
                                stopCond = true;
                                exportResults();
                            }
                        }
                        c.secret = c.studentnr + Message.secret;
                        c.status = Message.statusEnd;
                        replyMsg = JsonSerializer.Serialize<ClientInfo>(c);
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
            // Send a message to Client  
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

    public class ServerSimulator
    {
        public static void sequentialRun()
        {
            Console.Out.WriteLine("[Server] A sample server, sequential version ...");
            SequentialServer server = new SequentialServer();
            server.prepareServer();
            server.startServer();
        }
        public static void concurrentRun()
        {
            Console.Out.WriteLine("[Server] A sample server, concurrent version ...");
            ConcurrentServer server = new ConcurrentServer();
            server.prepareServer();
            Thread serverThread = new Thread(server.startServer);
            serverThread.Start();

            serverThread.Join();

            /*            ConcurrentServer server = new ConcurrentServer();
                        server.prepareServer();
                        Thread parentThread = new Thread(server.startServer);
                        Thread printingThread = new Thread(server.exportResults);
                        parentThread.Start();
                        printingThread.Start();
                        Thread.Sleep(10000);

                        printingThread.Join();
                        parentThread.Join();
                        */
        }
    }
    class Program
    {
        // Main Method 
       static void Main(string[] args)
        {
            Console.Clear();
            //ServerSimulator.sequentialRun();
            ServerSimulator.concurrentRun();
        }
        
    }
}
