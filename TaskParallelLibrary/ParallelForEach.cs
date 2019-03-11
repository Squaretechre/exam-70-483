using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    /*
     * Parallel.ForEach performs a parallel implementation of the foreach loop construction.
     * Parallel.ForEach accepts an IEnumerable collection and an action to be performed on each item.
     */
    internal class ParallelForEach
    {
        public static void Run()
        {
            var items = Enumerable.Range(0, 500);

            Parallel.ForEach(items, WorkOnItem);

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