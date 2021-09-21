using System;
using LibServer;
//using LibServerSolution;

// NOTE: THIS FILE MUST NOT CHANGE

namespace Server
{
    public class ServerSimulator
    {
        public Setting settings;

        public ServerSimulator()
        {   }

        /// <summary>
        /// initiates the server
        /// </summary>
        public void sequentialRun()
        {
            SequentialServer server = new SequentialServer();
            server.start();
        }
    }

    public class Program
    {
        /// <summary>
        /// Starts the simulation for a set of clients and produces the output results.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();
            new ServerSimulator().sequentialRun();

        }
    }
}
