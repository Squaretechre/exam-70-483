using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    // Parallel.For can be used to parallelize a for loop governed by a control variable.

    internal class ParallelFor
    {
        public static void Run()
        {
            var items = Enumerable.Range(0, 500).ToArray();

            Parallel.For(0, items.Length, i => { WorkOnItem(items[i]); });

            Console.WriteLine("Finished processing. Press any key to end.");
            Console.ReadKey();
        }

        private static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }
    }
}