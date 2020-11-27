// communication protocol:
// client -- connect --->              server
// client <-- ready -----              server
// client -- command / terminate -->   server
// client <-- confirmed ----           server
// client .... X .....                 server
//

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Sequential
{
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
    // DO NOT CHANGE
    public class Message
    {
        public const string ready = "READY";
        public const string confirmed = "CONFIRMED";
        public const string terminate = "[Terminating experiment]";
        public const string empty = "";
    }

    public class SequentialServer
    {
        // check all the required parameters for the server. How are they initialized? 
        public Socket listener;
        public IPEndPoint localEndPoint;
        public IPAddress ipAddress;
        public readonly int bufferSize = 1024;
        public String results = "";
        public int numOfClients = 0;
        public Setting settings;

        public SequentialServer(Setting settings)
        {
            // todo 1: which object is sending the settings? how is it used by the server?
            this.settings = settings;
            this.ipAddress = IPAddress.Parse(settings.serverIPAddress);
        }

        // todo [Assignment]: Why is implemented as virtual?
        public virtual void prepareServer()
        {
            Console.WriteLine("[Server] is ready to start ...");
            try
            {
                // todo 2: analyze how a listening socket is established. A non-blocking (what does it mean?) listen with max number of pending requests.
                // todo 3: What is the role of this pending size?
                localEndPoint = new IPEndPoint(this.ipAddress, settings.serverPortNumber);
                listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(settings.serverListeningQueue);
                // todo 4: analyse details of this listening loop. Everything in the server starts here.
                while (true)
                {
                    Console.WriteLine("Waiting for incoming connections ... ");
                    Socket connection = listener.Accept();
                    this.numOfClients++;
                    this.handleClient(connection);
                }
            }catch (Exception e){ Console.Out.WriteLine("[Server] Preparation: {0}",e.Message); }
        }

        // todo 5: what is the functionality of this method?
        public void handleClient(Socket con)
        {
            string data = "", reply = "";
            byte[] bytes = new Byte[bufferSize];

            this.sendMessage(con, Message.ready);
            int numByte = con.Receive(bytes);
            data = Encoding.UTF8.GetString(bytes, 0, numByte);
            reply = processMessage(data);
            this.sendMessage(con, reply);
        }

        // todo [Assignment]: Why is this implemented as virtual?
        public virtual string processMessage(String msg)
        {
            //todo 6: check how received messages are processed and handled. 
            Thread.Sleep(settings.serverProcessingTime);
            string replyMsg = Message.confirmed;

            try
            {
                switch (msg)
                {
                    case Message.terminate:
                        //todo 7: when this case is executed?
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("[Server] received from the client -> {0} ", msg);
                        Console.ResetColor();
                        Console.WriteLine("[Server] END : number of clients communicated -> {0} ", this.numOfClients);
                        break;
                    default:
                        //todo 8: which part of the protocol is implemented here?
                        replyMsg = Message.confirmed;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("[Server] received from the client -> {0} ", msg);
                        Console.ResetColor();
                        break;
                }
            }catch (Exception e){   Console.Out.WriteLine("[Server] Process Message {0}", e.Message);    }

            return replyMsg;
        }
        public void sendMessage(Socket connection, string msg)
        {
            byte[] encodedMsg = Encoding.UTF8.GetBytes(msg);
            connection.Send(encodedMsg);
        }
    }
}