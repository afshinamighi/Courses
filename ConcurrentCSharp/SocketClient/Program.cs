using System;
using Sequential;
//using Concurrent;
using Solution;

namespace Program
{

    class Program
    {
        // todo: check how the client side starts 
        static void Main(string[] args)
        {
            Console.Clear();
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine("\n (C)oncurrent, (S)equential, or (E)nd?");
                string inp = Console.ReadLine();
                switch (inp)
                {
                    case "S":
                        new SequentialClientsSimulator().SequentialSimulation();
                        break;
                    case "C":
                        new ConcurrentClientsSimulator().ConcurrentSimulation();
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
