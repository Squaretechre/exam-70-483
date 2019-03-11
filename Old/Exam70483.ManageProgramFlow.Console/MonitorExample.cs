
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // System.Threading.MonitorExample
    // Monitors model gated access to a resource
    // - Threads agree to "enter" the monitor before accessing shared resource
    //   - Other threads attempting to enter monitor while in use are blocked
    //   - May be recursively entered by same thread
    // - Threads agree to "exit" the monitor once access to resource is complete
    //   - Next thread waiting for entry to monitor (if any) is allowed in
    //   - Recursive entrance operations by same thread require balanced exit operations
    //
    //           ____ monitor _____ 
    //          |                  |
    //  T3  --->    T2 resource     ---> T1
    //          |__________________|
    //
    //
    // Table of locks is maintained by the CLR. Every object on the heap has in it's \
    // header the capability to store an index into that table, that identifies which
    // lock should be used whenever someone uses one of the monitor methods.
    // This means that ANY object can effectively be used a monitor, string, custom etc.
    //
    //                  object in the heap       table of locks
    //                  ___________________          ______
    //   objref   ---> [ flags / sync lock ] ---    [ lock ]
    //                 [  method table ptr ]    |   [ lock ]
    //                 |                   |    |___[ lock ]
    //                 |   object  fields  |        [ lock ]
    //                 |___________________|        [______]
    //
    public static class MonitorExample
    {
        public static void Run()
        {

        }
    }

    // without using a lock, multiple threads calling MoveBy and GetPos
    // could mutate the Widget2D class in such a manner that it ends up
    // in an invalid state.
    public class Widget2D
    {
        private int _x;
        private int _y;
        object _lock = new object();    // used to gate access to widget fields
                                        // can use any type of object

        public Widget2D(int x, int y)
        {
            _x = x;
            _y = y;
        }

        // because the same lock is used for both MoveBy and GetPos
        // the CLR will not allow two threads to work on either method at the
        // same time. one thread will aquire the lock and then all other threads
        // must wait to access MoveBy / GetPos until it is finished.

        // critical section
        public void MoveBy(int deltaX, int deltaY)
        {
            Monitor.Enter(_lock);      // ---
            _x += deltaX;              //    |__ access to fields is synchronized
            _y += deltaY;              //    |
            Monitor.Exit(_lock);       // ---

            // Exception-Safe Monitor Usage
            // IMPORTANT: if an exception occurs before calling Monitor.Exit, the
            // thread which has hold of the lock will keep hold of it, meaning no
            // other threads will ever be able to acquire it.
            // GetPos shows the usage of try / finally to always release the lock
        }

        // critical section
        public void GetPos(out int x, out int y)
        {
            Monitor.Enter(_lock);

            // use try / finally to ensure that the lock is released if
            // an exception is raised during execution to prevent infinite locking.
            // this can be expressed more succinctly using the C# specific syntax
            // shown in SetPos. the lock keyword provides syntactic sugar for the
            // same pattern used in this method. the C# compiler will ultimately
            // emmit the same pattern used here, however the syntax is for mare brief.
            try
            {
                x = _x;
                y = _y;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }

        // C# Specific Syntax
        // The lock keyword can be used as shorthand for the pattern above in GetPos
        public void SetPos(int x, int y)
        {
            lock (_lock)
            {
                _x = x;
                _y = y;
            }
        }
    }
}