using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.Json;
using System.Threading;
using LibData;


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

    public class Output
    {
        public string client_id { get; set; } // the id of the client that requests the book
        public string bookName { get; set; } // the name of the book to be reqyested
        public string status { get; set; } // final status received from the server
        public string borrowerName { get; set; } // the name of the borrower in case the status is borrowed, otherwise null
        public string borrowerEmail { get; set; } // the email of the borrower in case the status is borrowed, otherwise null
    }

    public class SimpleClient
    {
        // some of the fields are defined. 
        public Output result;
        public Socket clientSocket;
        public IPEndPoint serverEndPoint;
        public IPAddress ipAddress;
        public Setting settings;
        public string client_id;
        private string bookName;
        // all the required settings are provided in this file
        public string configFile = @"../ClientServerConfig.json";
        //public string configFile = @"../../../../ClientServerConfig.json"; // for debugging

        // todo: add extra fields here in case needed 

        /// <summary>
        /// Initializes the client based on the given parameters and seeting file.
        /// </summary>
        /// <param name="id">id of the clients provided by the simulator</param>
        /// <param name="bookName">name of the book to be requested from the server, provided by the simulator</param>
        public SimpleClient(int id, string bookName)
        {
            //todo: extend the body if needed.
            this.bookName = bookName;
            this.client_id = "Client " + id.ToString();
            this.result = new Output();
            result.bookName = bookName;
            result.client_id = this.client_id;
            // read JSON directly from a file
            try
            {
                string configContent = File.ReadAllText(configFile);
                this.settings = JsonSerializer.Deserialize<Setting>(configContent);
                this.ipAddress = IPAddress.Parse(settings.serverIPAddress);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("[Client Exception] {0}", e.Message);
            }
        }

        /// <summary>
        /// Establishes the connection with the server and requests the book according to the specified protocol.
        /// Note: The signature of this method must not change.
        /// </summary>
        /// <returns>The result of the request</returns>
        public Output start()
        {
            
            // todo: implement the body to communicate with the server and requests the book. Return the result as an Output object.
            // Adding extra methods to the class is permitted. The signature of this method must not change.

            return result;
        }

    }
}
