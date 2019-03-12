using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    /*
     * Parallel.Invoke can start a large number of tasks at once.
     * You have no control over the order in which the tasks are started,
     * or which processors they're assigned to.
     * Parallel.Invoke returns when all tasks have completed.
     */
    internal class ParallelInvoke
    {
        public static void Run()
        {
            Parallel.Invoke(Task1, Task2);
            Parallel.Invoke(() =>
            {
                Console.WriteLine("Task 1 in lambda starting");
                Thread.Sleep(1000);
                Console.WriteLine("Task 1 in lambda ending");
            }, () =>
            {
                Console.WriteLine("Task 2 in lambda starting");
                Thread.Sleep(1000);
                Console.WriteLine("Task 2 in lambda ending");
            });
            Console.WriteLine("Finished processing. Press any key to end.");
            Console.ReadKey();
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 ending");
        }

        private static void Task2()
        {
            Console.WriteLine("Task 2 starting");
            Thread.Sleep(2000);
            Console.WriteLine("Task 2 ending");
        }
    }
}