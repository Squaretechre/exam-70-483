using System;
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Threads are started explicitly, execution begins when Start is called.
    // Threads can be configured before they're started, setting info such as:
    // - Thread name, useful for debugging.
    // - Thread priority, better inform the scheduler of how it should prioritise.
    internal class Program
    {
        //private readonly Action<string> _displayMessage = message => Console.WriteLine(message);

        // The field being used as the control mechanism for thread lifetime
        static volatile bool ThreadsShouldLive = true;
        
        private static void Main()
        {
            // The thread id output in SayHello will be different to that of the
            // main thread id which is used to start the "Hello, Thread".
            Console.WriteLine("[{0}] Main called", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("[{0}] Processor/core count = {1}",
                Thread.CurrentThread.ManagedThreadId,
                Environment.ProcessorCount);

            // Set SayHello as the thread entry point method
            var thread1 = new Thread(SayHello)
            {
                Name = "Hello Thread",
                Priority = ThreadPriority.BelowNormal
            };
            thread1.Start();

            // Can also pass arguments to a thread
            // Set DisplayMessage as the thread entry point method
            var thead2 = new Thread(DisplayMessage);
            thead2.Start("Hello again, world!");

            // Can also use instance methods as the delegate for a thread,
            // set it to the DisplayMessage of an instance of the Messenger class
            var messenger = new Messenger("Hello one more time, world!");
            var thread3 = new Thread(messenger.DisplayMessage);
            thread3.Start();

            // Thread execution:
            // Execution continues until a thread returns from it's entry point method
            // Either:
            // - As a result of a standard method return, no errors
            //      - if there are no errors executing the thread delegate then
            //        the CLR knows the thread is done and begins the cleanup of it
            // 
            // - As the result of an unhandled exception
            //      - encountered by the thread itself ("synchronous exception")
            //        ex. thread x incurred an error due to thread x running code.
            //          - an exception will raise to the top of a thread's call stack,
            //            and if it goes unhandled it will terminate excution of the thread
            //            and the CLR will begin cleanup
            //
            // - Induced by another thread using Interrupt or Abort ("asynchronous exception")
            //      - an asynchronous exception is an exception that occurs in the context
            //        of a thread but is induced by another thread.
            //        ex. thead y injected an exception into thread x by calling Interrupt or
            //        Abort on the thread x object.
            //
            //      - usually done by another object that has a reference to the thread and
            //        invokes Interrupt or Abort on the thread object.

            // Can also check to see if a thread is still alive using IsAlive to check
            // the thread's execution status.
            // If the thread hasn't returned from it's main execution or hasn't encountered
            // an unhandled exception, it will return true.
            // IsAlive is an "instantaneous snapshot", by the time you come to use the result
            // of IsAlive the execution state of the thread may have already changed.
            var isThreadAlive = thread3.IsAlive;

            // Manually stopping threads / thread shutdown choreography
            // You must implement your own mechanism for marshalling threads.
            // Above the field ThreadsShouldLive is used inside a while loop in the
            // method IWillBeManuallyShutDown. When it is changed to false, any thread
            // using IWillBeManuallyShutDown as it's main execution will see the request
            // for it to cease work when it reaches the next evaluation of the loop.
            // The thread/s will not be torn down immediately, it may take them a short
            // while to reach the next evaluation of the loop.
            // The Join method on Thread is a blocking mechanism that will block work
            // on the marshalling thread until the CLR indicates that the thread
            // for who it has a reference to has exited, i.e it's IsAlive property
            // is false, indicating that is finished.
            // There are overloads for the Join method, you are able to define a timeout
            // Join()     = wait infinitely, 
            // Join(1000) = pass an int val representing milliseconds

            Console.WriteLine("[{0}] Main done", Thread.CurrentThread.ManagedThreadId);
            Console.Read();
        }

        // Can ask the CLR about the current thread with Thread.CurrentThread
        private static void SayHello()
        {
            Console.WriteLine("[{0}] Hello, world!", Thread.CurrentThread.ManagedThreadId);
        }

        private static void DisplayMessage(object stateArg)
        {
            var message = stateArg as string;
            if (message != null)
                Console.WriteLine("[{0}] {1}", Thread.CurrentThread.ManagedThreadId, message);
        }

        private static void IWillBeManuallyShutDown()
        {
            // The ThreadsShouldLive field is marked as volatile to stop 
            // the JIT from looking at the field and deciding to cache 
            // it's value in a register due to no other code in this block 
            // mutating it's state. This stops a snapshot of the fields
            // state being taken, which wouldn't be helpful as a control mechanism.
            // We want the thread to be able to see changes to it's state.
            while (ThreadsShouldLive)
            {
                Console.WriteLine("Hello, is it me you're looking for?");
                Thread.Sleep(1000);
            }
        }
    }
}