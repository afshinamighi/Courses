using System;
using System.Reflection;
using System.Threading;

namespace Examples
{
    public class ExampleLocals
    {
        public ExampleLocals(){ }
        public void ExampleOne(int max_count)
        {
            int x = 0, max = max_count;
            Thread t1 = new Thread( ()=> { for (int i = 0; i < max; i++) x++; } );
            Thread t2 = new Thread(() => { for (int i = 0; i < max; i++) x--; } );

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("[{0}] local vars defined in the method: x = {1}",MethodBase.GetCurrentMethod().Name , x);
        }
        public void multiRun(int m, int max_count)
        {
            for (int i = 0; i < m; i++)
                this.ExampleOne(i*max_count);
        }
    }
}
