using System;
using UserHelperSolution;

// NOTE: THIS FILE MUST NOT CHANGE

namespace LibHelper
{
    public class HelperSimulator
    {
        public void sequentialRun()
        {
            SequentialHelper server = new SequentialHelper();
            server.start();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            HelperSimulator hs = new HelperSimulator();
            hs.sequentialRun();
        }
    }
}
