using System;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.IO;
using LibData;


namespace LibServer
{
    // Note: Do not change this class.
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


    // Note: Complete the implementation of this class. You can adjust the structure of this class. 
    public class SequentialServer
    {
        public SequentialServer()
        {
            //todo: implement the body. Add extra fields and methods to the class if it is needed
        }

        public void start()
        {
            //todo: implement the body. Add extra fields and methods to the class if it is needed

        }
    }

}



