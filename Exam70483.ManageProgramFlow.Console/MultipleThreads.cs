using System;
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    internal static class MultipleThreads
    {
        // shared resource
        // all 11 threads have access to this
        // 10 instances and the main thread
        private static int sum = 0;

        public static void Run()
        {
            var threads = new Thread[10];

            for (var n = 0; n < threads.Length; n++)
            {
               threads[n] = new Thread(AddOne); 
               threads[n].Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            Console.WriteLine(sum);
            Console.Read();
        }

        // Race Conditions
        // A "race condition" occurs when the outcome may be affected by timing
        // - e.g, uncontrolled access to a critical section
        // 
        // The AddOne method will go through the following transformations:
        // CSC -> IL -> JIT -> x86 (platform dependant)
        // Once it is transformed into machine code the schedular that runs the
        // threads could suspend / start a different thread midway through it's
        // execution, this could leave registers an in inconsistent state, e.g.
        //
        // Given the machine code generated for the method:
        // 1. mov eax, dword ptr [sum]          - read sum from memory into eax
        // 2. inc eax                           - increment sum
        // 3. mov dword ptr [sum], eax          - write sum from eax back to memory
        //
        // And the scenario involving 2 threads:
        // - Thread 1 is given time on the CPU and manages to make it up to line 2.
        // - At this point register eax is = 1 but hasn't been stored back to [sum].
        // - The scheduler then suspends thread 1 and gives Thread 2 CPU time.
        // - Thread 2 then makes it to line 2 also but is then suspended to give Thread 1 CPU time.
        // - Thread 1 then continues to line 3 and stores 1 into [sum] and finishes.
        // - Thread 2 then also does the same, storing 1 into [sum].
        // - The result is that [sum] is equal to 1, rather than 2.
        //
        // The schedular virtualizes the CPU registers for each thread to make it
        // appear as if they have exclusive use of the processor.
        //
        // Atomic Updates
        // Most processors support atomic updates of word-sized data
        // - word sized data is data that is capable of fitting in a register supported by the procesor.
        //   for 32bit processors these are 32bit quantities, e.g an int
        //   for 64bit processors these are 64bit quantities.
        //
        // Atomic updates are supported on Intel processors with instructions such as:
        //
        // mov ecx, dword ptr [sum]             - move address of sum into ecx
        // mov eax, 1                           - put value 1 into register eax
        // lock xadd dword ptr [ecx], eax       - performs uninteruptable read, modify, write by
        //                                        getting the value from the address in ecx,
        //                                        adding the value in eax and then writing back to ecx
        // 
        // Can be interupted before of after the lock but the xadd instruction ensures
        // that it works correctly on multiple cores.
        // The above however is platform specific, the FCL provides a processor-independent
        // suite of atomic updates:
        // - System.Threading.Interlocked.xxx
        //   static void AddOne()
        //   {
        //      Interlocked.Increment(ref sum);     - thread-safe read/modify/write
        //      ^ interlocked has multiple static methods
        //   }
        //    
        private static void AddOne()
        {
            // critical section of code
            // - a "critical section" is a region of code that accesses a shared resource
            //   sum++ is executed in the context of multiple threads
            sum++;
            // Interlocked.Increment(ref sum);
        }
    }
}