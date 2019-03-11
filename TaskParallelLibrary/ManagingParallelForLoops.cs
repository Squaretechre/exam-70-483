using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    /*
     * Parallel.For / ForEach return a value of type ParallelLoopState.
     * ParallelLoopState allows code being iterated to control the iteration process.
     * ParallelLoopState can be used to determine whether or not the loop successfully completed.
     * Stop() doesn't instantly stop all executing iterations.
     * Stop() also doesn't mean that any number > 200 will never run, there is no guarantee that items > 200 will run before items with higher numbers.
     * Calling Stop() on the 200th iteration means that
     * indexes lower than 200 might not be performed.
     * Calling Break() 
     */
    internal class ManagingParallelForLoops
    {
        public static void Run()
        {
            var items = Enumerable.Range(0, 500).ToArray();

            ParallelLoopResult result = Parallel.For(0, items.Length, (int i, ParallelLoopState loopState) =>
            {
                if (i == 200)
                {
                    loopState.Stop();
                }

                WorkOnItem(items[i]);
            });

            Console.WriteLine("Completed: " + result.IsCompleted);
            Console.WriteLine("Items: " + result.LowestBreakIteration);

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