using System;
using System.IO;
using System.Text;
using System.Text.Json;
using Sequential;
using Concurrent;
//using Solution;


namespace Program
{
    // todo 2: analyse the flow of simulator.
    public class ServerSimulator
    {
        public Setting settings;
        //public string configFile = "../ClientServerConfig.json";
        public string configFile = "../../../../ClientServerConfig.json"; // for debugging


        public ServerSimulator()
        {
            this.configure();
        }
        public void configure()
        {
            // read JSON directly from a file
            try
            {
                string configContent = File.ReadAllText(configFile);
                this.settings = JsonSerializer.Deserialize<Setting>(configContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("[Server] Configuration {0}", e.Message);
                Environment.Exit(0);
            }
        }

        public void sequentialRun()
        {
            Console.Out.WriteLine("[Server] A sequential server is ready ...");
            SequentialServer server = new SequentialServer(settings);
            server.prepareServer();
        }

        public void concurrentRun()
        {
            Console.Out.WriteLine("[Server] A concurrent server is ready ...");
            try
            {
                ConcurrentServer server = new ConcurrentServer(settings);
                server.prepareServer();
            }
            catch (Exception e)
            {
                Console.WriteLine("[ServerSimulator] Concurrent run {0}",e.Message);
                Environment.Exit(0);
            }
        }
    }

    public class Program
    {
        // todo 1: check the flow of main mehod as the starting point 
        static void Main(string[] args)
        {

            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.WriteLine("\n (C)oncurrent, (S)equential or (E)nd?");
                string inp = Console.ReadLine();
                switch (inp)
                {
                    case "S":
                        new ServerSimulator().sequentialRun();
                        break;
                    case "C":
                        new ServerSimulator().concurrentRun();
                        break;
                    case "E":
                        stop = true;
                        break;
                    default:
                        Console.WriteLine("\n Invalid input ... ");
                        break;
                }
            }
        }
    }
}
