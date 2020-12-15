using System;
using Exercise; 
//using Solution; // will be provided later

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPhilosphers = 5 , iteration = 500;
            Table table = new Table(numPhilosphers);

            Console.WriteLine("[Dinining Philospher] Dining with one fork is going to start ...");
            table.startOneForkDining(iteration);

            Console.WriteLine("[Dinining Philospher] Dining with two forks is going to start (press enter)...");
            Console.ReadLine();

            //table.startTwoForksDining(iteration);
            Console.WriteLine("[Dinining Philospher] End of the dinner ...");
        }
    }
}
