using System;
using BookHelper;
//using BookHelperSolution;

// NOTE: THIS FILE MUST NOT CHANGE

namespace LibHelper
{
    public class HelperSimulator
    {
        /// <summary>
        /// initiates the helper
        /// </summary>
        public void sequentialRun()
        {
            SequentialHelper server = new SequentialHelper();
            server.start();
        }
    }

    class Program
    {
        /// <summary>
        /// Starts the simulation for a set of clients and produces the output results.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();
            HelperSimulator hs = new HelperSimulator();
            hs.sequentialRun();
        }
    }
}
