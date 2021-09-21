using System;
using System.Threading;
using System.Text.Json;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using LibData;

namespace UserHelper
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

    public class SequentialHelper
    {
        public SequentialHelper()
        {
            //todo: implement the body. Add extra fields and methods to the class if needed
        }

        public void start()
        {
            //todo: implement the body. Add extra fields and methods to the class if needed
        }
    }
}
