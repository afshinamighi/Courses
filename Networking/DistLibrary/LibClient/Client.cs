using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Threading;
using LibData;
//todo: implement full client such that it follows the protocol discussed in the assignment. 

namespace LibClient
{
    public class Setting
    {
        public int serverPortNumber { get; set; }
        public int bookHelperPortNumber { get; set; }
        public int userHelperPortNumber { get; set; }
        public string serverIPAddress { get; set; }
        public string bookHelperIPAddress { get; set; }
        public string userHelperIPAddress { get; set; }
        public int serverListeningQueue { get; set; }
    }

    public class SimpleClient
    {
        public string outcome;
        public Socket clientSocket;
        public IPEndPoint serverEndPoint;
        public IPAddress ipAddress;
        public Setting settings;
        public string user_id;
        private string bookName;
        public string configFile = @"../ClientServerConfig.json";
        //public string configFile = @"../../../../ClientServerConfig.json"; // for debugging

        public SimpleClient(int id, string bookName)
        {
            //todo: implement the body
        }

        public string start()
        {
            //todo: implement the body

            return outcome;
        }

    }
}
