// communication protocol:
// client -- connect --->              server
// client <-- ready -----              server
// client -- command / terminate -->   server
// client <-- confirmed ----           server
// client .... X .....                 server
//

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace Sequential {
    // todo 1: check setting file provided as json format. Compare the fields with this class
    // DO NOT CHANGE
    public class Setting
    {
        public int serverPortNumber { get; set; }
        public string serverIPAddress { get; set; }
        public int clientMaxStartingTime { get; set; }
        public int experimentNumberOfClients { get; set; }
        public int delayForTermination { get; set; }
        public int clientMinStartingTime { get; set; }
        public string votingList { get; set; }
        public int serverListeningQueue { get; set; }
        public int serverProcessingTime { get; set; }
        public string commands_sep { get; set; }
        public string command_msg_sep { get; set; }
    }
    // todo 2: check required messages for the protocol
    // DO NOT CHANGE
    public class Message
    {
        public const string ready = "READY";
        public const string confirmed = "CONFIRMED";
        public const string terminate = "[Terminating experiment]";
        public const string empty = "";
    }

    public class SimpleClient
    {
        // todo 3: check all the required parameters for the client. How are they initialized? 
        public Socket clientSocket;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress;
        public Setting settings;
        public int waitingTime = 0;
        public readonly int bufferSize = 1024;
        public int client_id = 0;
        public string cmd = "", cmd_message="";
        public char commands_sep, command_msg_sep;

        public SimpleClient(int id, Setting settings)
        {
            this.settings = settings;
            client_id = id;
            // todo 4: implement a piece of code by which a command is selected (randomly) from the provided voting list (check settings)
            cmd = "[Replace this with a command from the list provided by settings]";
            cmd_message = "ClientId="+client_id.ToString()+settings.command_msg_sep+cmd;

            this.ipAddress = IPAddress.Parse(settings.serverIPAddress);
            waitingTime = new Random().Next(settings.clientMinStartingTime, settings.clientMaxStartingTime);
        }
        public void prepareClient()
        {
            try
            {
                // todo 5: Analyse how the remote endpoint for the socket is establised.
                localEndPoint = new IPEndPoint(ipAddress, settings.serverPortNumber);
                clientSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            }
            catch (Exception e){ Console.Out.WriteLine("[Client] Preparation: {0}", e.Message); }
        }
        // todo 6: check the sequence of method calls
        public void communicate()
        {
            this.startCommunication();
            this.endCommunication();
        }
        // todo 7: check when and how the client closes the connection
        public void endCommunication()
        {
            Console.Out.WriteLine("[Client] End of communication .. X .. ");
            clientSocket.Close();
        }
        public void startCommunication()
        {
            byte[] messageReceived = new byte[bufferSize];
            int numBytes = 0;
            String rcvdMsg = null;
            string reply = "";
            bool stop = false;
            // a random delay for each client
            Thread.Sleep(waitingTime);
            Console.Out.WriteLine("[Client] **************");

            // todo 8: analyse carefully how the communication protocol is implemented
            try
            {
                // Connect Socket to the remote endpoint 
                clientSocket.Connect(localEndPoint);
                Console.WriteLine("[Client] connected to --> {0} ", clientSocket.RemoteEndPoint.ToString());

                //todo 9: This loop implements communication protocol on the client side
                while(!stop)
                {
                    numBytes = clientSocket.Receive(messageReceived);
                    rcvdMsg = Encoding.UTF8.GetString(messageReceived, 0, numBytes);
                    Console.WriteLine("[Client] from Server <-- {0}", rcvdMsg);
                    reply = this.processMessage(rcvdMsg);
                    if (reply != Message.empty)
                        this.sendMessage(reply);
                    else
                        stop = true;
                }
            }
            catch (Exception e)
            { Console.WriteLine(e.Message);  }
        }
        public string processMessage(string msg)
        {
            // todo 10: check how the received message is processed and what would be a proper reply
            string replyMsg = Message.empty;
            try
            {
                switch (msg)
                {
                    case Message.ready:
                        if (client_id==-1) // last client terminates the experiment
                            replyMsg = Message.terminate;
                        else
                            replyMsg = this.cmd_message;
                        break;
                    case Message.confirmed:
                        replyMsg = Message.empty;
                        break;
                }
            }
            catch (Exception e)
            {   Console.Out.WriteLine("[Client] Process Message {0}", e.Message); }

            return replyMsg;
        }
        // todo 11: check steps for sending messages
        public void sendMessage(string msg)
        {
            // some coloring in console just for better readability
            if(msg==this.cmd)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            if(msg==Message.terminate)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Out.WriteLine("[Client] Message to be sent: {0}", msg);
            Console.ResetColor();

            byte[] messageSent = Encoding.UTF8.GetBytes(msg);
            int byteSent = clientSocket.Send(messageSent);
        }
    }

    // todo 12: This class implements a simulator for running clients. Analyse how all the clients are started to communicate with the server.
    public class SequentialClientsSimulator
    {
        private SimpleClient[] clients;
        public Setting settings;
        //public string configFile = "../ClientServerConfig.json";
        public string configFile = "../../../../ClientServerConfig.json"; // for debugging


        public SequentialClientsSimulator()
        {
            configure();
            clients = new SimpleClient[settings.experimentNumberOfClients];
            for (int i = 0; i < settings.experimentNumberOfClients; i++)
            {
                clients[i] = new SimpleClient(i+1, settings); // id>0 means this is not a terminating client
            }
        }
        public void configure()
        {
            // read JSON directly from a file
            try
            {
                string configContent = File.ReadAllText(configFile);
                this.settings = JsonSerializer.Deserialize<Setting>(configContent);
            }
            catch (Exception e) {
                Console.WriteLine("[Server] Configuration {0}", e.Message);
                Environment.Exit(0);
            }
        }

        public void SequentialSimulation()
        {
            Console.Out.WriteLine("\n[ClientSimulator] Sequential simulator is going to start with {0}", settings.experimentNumberOfClients);
            for (int i = 0; i < settings.experimentNumberOfClients; i++)
            {
                clients[i].prepareClient();
                clients[i].communicate();
            }

            Console.Out.WriteLine("\n[ClientSimulator] All clients finished with their communications ... ");

            Thread.Sleep(settings.delayForTermination);

            SimpleClient endClient = new SimpleClient(-1, settings); // this is a terminating client: it will terminate the whole simulation
            endClient.prepareClient();
            // todo 13: check what happens in server side after this client.
            endClient.communicate();
        }
    }
}
