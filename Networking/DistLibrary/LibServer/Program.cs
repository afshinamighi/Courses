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

        public void sequentialRun()
        {
            SequentialServer server = new SequentialServer();
            server.start();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            new ServerSimulator().sequentialRun();

        }
    }
}
