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
        public const string cmd_close = "Closing current connection";
    }

    public class SimpleClient
    {
        public Socket clientSocket;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        public readonly int portNumber = 11111;
        public readonly int minWaitingTime = 10, maxWaitingTime = 100;
        public readonly int bufferSize = 1024;
        public int waitingTime = 0;
        private String msgToSend;
        private bool finishing = false;

        public SimpleClient(bool fin)
        {
            waitingTime = new Random().Next(minWaitingTime, maxWaitingTime);
            finishing = fin;
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
                        if (finishing)
                            replyMsg = Message.cmd_close;
                        else
                            replyMsg = Message.cmd_os;
                        break;
                    default:
                        // a default process
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
            // wait for a while
            Thread.Sleep(waitingTime);
            // Data buffer 
            byte[] messageReceived = new byte[bufferSize];
            int numBytes = 0;
            String rcvdMsg = null;
            string reply = "";

            try
            {
                // Connect Socket to the remote endpoint 
                clientSocket.Connect(localEndPoint);
                // print connected EndPoint information  
                Console.WriteLine("[Client] connected to -> {0} ", clientSocket.RemoteEndPoint.ToString());

                // Receive the messagge using the method Receive().
                numBytes = clientSocket.Receive(messageReceived);
                rcvdMsg = Encoding.ASCII.GetString(messageReceived, 0, numBytes);
                reply = this.processMessage(rcvdMsg);
                this.sendReply(reply);
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
        private SimpleClient[] clients;
        public readonly int waitingTimeForStop = 200;


        public ClientsSimulator(int n, int t)
        {
            numberOfClients = n;
            clients = new SimpleClient[numberOfClients];
            for (int i = 0; i < numberOfClients; i++)
            {
                clients[i] = new SimpleClient(false);
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

            SimpleClient endClient = new SimpleClient(true);
            endClient.prepareClient();
            endClient.startCommunication();
            endClient.endCommunication();
        }
    }
}
