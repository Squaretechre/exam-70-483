using System;
using System.Linq;
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    internal class ThreadPoolDemo
    {
        public static void Run()
        {
            // Thread Pool
            // The CLR proves a per-process thread pool, it:
            // - Allows threads to be "borrowed" for brief concurrent operations
            // - Adds and removes threads from the pool based on demand
            // - Allows cost of thread startup & tear down to be amortized over life of the app
            // - Pooled threads have their IsBackground property set to true
            //      - Normally when threads are instantiated this is set to false
            //      - When IsBackground is set to false, if the thread is the only thread
            //        left in the application, it tells the CLR that it is important and
            //        should not be torn down until it has finished
            //      - IsBackground set to true tells the CLR the opposite and lets it know
            //        that the particular thread can be torn down if the process is quit
            //        before it has finished
            //      - This is true of pooled threads which have it set to true by default
            var messageArgs = new MessageArgs(10, "Hi, world!");
            var thread5 = new Thread(DisplayManyMessages)
            {
                IsBackground = true 
            };
            thread5.Start(messageArgs);
            Console.WriteLine("Done executing thread 5");
            Console.Read();

            // Three styles of interaction with the thread pool are supported
            // - ThreadPool.QueueUserWorkItem
            //      - make a request to the thread pool to call a function and let
            //        the CLR take care of dispatching a thread out of the pool
            // - Delegate.BeginInvoke
            //      - all delegates have a method called BeginInvoke which is an 
            //        interface onto the thread pool
            // - Asynchronous I/O
            //      - leveraging I/O devices specifically

            // ThreadPool.QueueUserWorkItem
            // Asks the CLR to dispatch a thread from the pool to invoke a particular
            // method by passing the address of the method to invoke to QueueUserWorkItem.
            ThreadPool.QueueUserWorkItem(DisplayMessage, "Hello, world!");
            //                          |_______________________________|
            //                                          |
            //                          params are bundled up and placed into
            //                          a standard FIFO queue, the CLR will
            //                          pull requests off of the queue in
            //                          FIFO order.
            //
            // Callback Invocation order is not guaranteed!
            // All threads in the pool act as readers of the queue, dequeuing the first
            // method call off of the queue.
            // Due to this, the callback invocation order can not be guaranteed. Ex.
            // The thread pool has 2 threads and the queue looks as follows:
            // Method D | Method C | Method B | Method A |
            //
            // Thread 1 picks up Method A which is a long running method.
            // Thread 2 then picks up Methods B, C and D during this time.
            // Whilst the calls were queued up in the order A, B, C, D
            // the actual completion of execution was B, C, D, A

            // The above queues up a request to the thread pool, it is then upto the
            // CLR to create a thread if non exist in the pool and then dispatch that
            // thread, or to dispatch an existing thread to invoke the method.
            // We then return straight away and continue execution after the request is queued.

        }

        private static void DisplayMessage(object stateArg)
        {
            Console.WriteLine(stateArg);
        }

        private static void DisplayManyMessages(object threadArgs)
        {
            var messageArgs = (MessageArgs)threadArgs;
            foreach (var i in Enumerable.Repeat(0, messageArgs.NumberOfMessages))
            {
                Console.WriteLine(messageArgs.Message);
            }
        }

        private struct MessageArgs
        {
            public readonly int NumberOfMessages;
            public readonly string Message;

            public MessageArgs(int numberOfMessages, string message)
            {
                NumberOfMessages = numberOfMessages;
                Message = message;
            }
        }

    }
}