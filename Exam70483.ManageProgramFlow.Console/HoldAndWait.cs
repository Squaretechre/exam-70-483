using System.Collections.Generic;
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Hold & Wait
    // Sometimes a thread needs to wait for something "while" holding a lock
    // - e.g: a resource to be provided or replenished
    // - e.g: another lock
    // 
    // Resource replenishment or other condition
    // - producer/consumer model for resource handling
    // - blocking semantics for consumer when resource(s) not available
    //
    // Multiple lock acquisition
    // - atomic updates of multiple resources, each protected by own lock
    //
    // Example of a queue with multiple threads reading/writing to it
    // if the queue is empty a thread may need to wait until items are added to it

    // Monitor.Wait
    // - Used in a while loop
    // - Puts the calling thread to sleep, but first lets the lock go
    // - Relinquishes control of whatever lock it has acquired
    // - All threads hitting Monitor.Wait will be put to sleep and file into line
    //   until whatever condition that put it to sleep is met

    // Monitor.PulseAll
    // - Used to inform any threads put to sleep by Monitor.Wait that are waiting,
    //   that they should woken up and resume execution
    // - Monitor.PulseAll will say to the CLR, while I still have control of the lock,
    //   goahead and wake up any waiting threads that are queued modelled by Monitor.Wait,
    //   and move them to the queue of people back at the front door of the monitor trying to
    //   get in
    // - The PulseAll thread will then release the lock
    // - The while loop is used with Monitor.Wait, as if there are more threads waiting to
    //   consume than resources available, the while loop must evaluate the locking condition
    //   ready to put any newly awoken threads back to sleep until further resources are available
    public static class HoldAndWait
    {
        public static void Run()
        {
        }
    }

    public class Bakery
    {
        private readonly Queue<Donut> _donutTray = new Queue<Donut>();

        public Donut GetDonut()
        {
            lock (_donutTray)
            {
                while (_donutTray.Count == 0)
                    Monitor.Wait(_donutTray);

                return _donutTray.Dequeue();
            }
        }

        public void RefillTray(Donut[] freshDonuts)
        {
            lock (_donutTray)
            {
                foreach (var donut in freshDonuts)
                    _donutTray.Enqueue(donut);

                // wake up sleeping threads
                Monitor.PulseAll(_donutTray);
            }
        }
    }

    public class Donut
    {
    }
}