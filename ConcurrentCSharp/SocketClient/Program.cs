using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
/* Note: If you are using .net core 2.1, you need to install System.Text.Json (use NuGet). */
using System.Text.Json;
using System.Threading;

namespace SocketClient
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

    public class Client
    {
        public Socket clientSocket;
        private ClientInfo info;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public readonly int portNumber = 11111;
        public readonly int minWaitingTime = 50, maxWaitingTime = 100;
        public int waitingTime = 0;
        string baseStdNumber = "0700";

        private String msgToSend;

        public Client(bool finishing, int n)
        {
            waitingTime = new Random().Next(minWaitingTime, maxWaitingTime);
            info = new ClientInfo();
            info.classname = " INF2X ";
            info.studentnr = this.baseStdNumber + n.ToString();
            info.ip = "127.0.0.1";
            info.clientid = finishing ? -1 : 1;
        }

        public string getClientInfo()
        {
            return JsonSerializer.Serialize<ClientInfo>(info);
        }
        public void prepareClient()
        {
            try
            {
                // Establish the remote endpoint for the socket.
                localEndPoint = new IPEndPoint(ipAddress, portNumber);
                // Creation TCP/IP Socket using  
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("[Client] Preparation failed: {0}", e.Message);
            }
        }
        public string processMessage(string msg)
        {
            Console.WriteLine("[Client] from Server -> {0}", msg);
            string replyMsg = "";

            try
            {
                switch (msg)
                {
                    case Message.welcome:
                        replyMsg = this.getClientInfo();
                        break;
                    default:
                        ClientInfo c = JsonSerializer.Deserialize<ClientInfo>(msg.ToString());
                        if (c.status == Message.statusEnd)
                        {
                            replyMsg = Message.stopCommunication;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("[Client] processMessage {0}", e.Message);
            }
            return replyMsg;
        }
        public void startCommunication()
        {
            Console.Out.WriteLine("[Client] **************");
            Thread.Sleep(waitingTime);
            // Data buffer 
            byte[] messageReceived = new byte[1024];
            int numBytes = 0;
            String rcvdMsg = null;
            Boolean stop = false;
            string reply = "";

            try
            {
                // Connect Socket to the remote endpoint 
                clientSocket.Connect(localEndPoint);
                // print connected EndPoint information  
                Console.WriteLine("[Client] connected to -> {0} ", clientSocket.RemoteEndPoint.ToString());

                while (!stop)
                {
                    // Receive the messagge using the method Receive().
                    numBytes = clientSocket.Receive(messageReceived);
                    rcvdMsg = Encoding.ASCII.GetString(messageReceived, 0, numBytes);
                    reply = this.processMessage(rcvdMsg);
                    this.sendReply(reply);
                    if (reply.Equals(Message.stopCommunication))
                    {
                        stop = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void sendReply(string msg)
        {
            // Create the message to send
            Console.Out.WriteLine("[Client] Message to be sent: {0}", msg);
            byte[] messageSent = Encoding.ASCII.GetBytes(msg);
            int byteSent = clientSocket.Send(messageSent);
        }
        public void endCommunication()
        {
            Console.Out.WriteLine("[Client] End of communication to -> {0} ", clientSocket.RemoteEndPoint.ToString());
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }

    public class ClientsSimulator
    {
        private int numberOfClients;
        private Client[] clients;
        public readonly int waitingTimeForStop = 2000;


        public ClientsSimulator(int n, int t)
        {
            numberOfClients = n;
            clients = new Client[numberOfClients];
            for (int i = 0; i < numberOfClients; i++)
            {
                clients[i] = new Client(false, i);
            }
        }

        public void SequentialSimulation()
        {
            Console.Out.WriteLine("\n[ClientSimulator] Sequential simulator is going to start ...");
            for (int i = 0; i < numberOfClients; i++)
            {
                clients[i].prepareClient();
                clients[i].startCommunication();
                clients[i].endCommunication();
            }

            Console.Out.WriteLine("\n[ClientSimulator] All clients finished with their communications ... ");

            Thread.Sleep(waitingTimeForStop);

            Client endClient = new Client(true, -1);
            endClient.prepareClient();
            endClient.startCommunication();
            endClient.endCommunication();
        }

        public void ConcurrentSimulation()
        {
            Console.Out.WriteLine("[ClientSimulator] Concurrent simulator is going to start ...");
            // todo: In order to test the final solution, it is recommended to implement this method.


        }
    }
    class Program
    {
        // Main Method 
  /*      static void Main(string[] args)
        {
            Console.Clear();
            int wt = 5000, nc = 20;
            ClientsSimulator clientsSimulator = new ClientsSimulator(nc, wt);
            clientsSimulator.SequentialSimulation();
            Thread.Sleep(wt);
            // todo: Uncomment this, after finishing the method.
            //clientsSimulator.ConcurrentSimulation();

        }
*/
    }
}
