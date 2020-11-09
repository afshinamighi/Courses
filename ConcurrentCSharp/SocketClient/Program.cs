using System;
using Exercise;
using System.Threading;


namespace Program
{
    class Program
    {
        // Main Method 
        static void Main(string[] args)
        {
            Console.Clear();
            int wt = 1000, nc = 10;
            ClientsSimulator clientsSimulator = new ClientsSimulator(nc, wt);
            clientsSimulator.SequentialSimulation();
            Thread.Sleep(wt);
        }
    }
}
