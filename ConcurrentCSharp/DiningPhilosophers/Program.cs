using System;
using System.Threading;
using DiningNormal; // todo: After running the normal version, comment DiningNormal and uncomment Exercise.
//using Exercise;
//using Solution // will be provided later

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPhilosphers = 5 , iteration = 100;
            Table table = new Table(numPhilosphers);

            Console.WriteLine("[Dinining Philospher] Sequential Dining is going to start ...");
            table.startSequentialDining(iteration);

            Console.ReadLine();
            Console.WriteLine("[Dinining Philospher] Concurrent Dining is going to start ...");

            table.startConcurrentDining(iteration);

            Console.WriteLine("[Dinining Philospher] End of the dinner ...");
        }
    }
}
