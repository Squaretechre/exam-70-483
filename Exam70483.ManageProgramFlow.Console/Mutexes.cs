using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Mutexes
    // A mutex is a Win32 kernel object
    // - System.Threading.Mutex provides an FCL wrapper for managed code
    //
    // Benefits:
    // - Supports timeout-limited lock acquisition
    // - Nameable; enabling cross-process (same-machine) thread synchronization
    // - Enables deadlock-free multiple lock acquisition via WaitHandle.WaitAll
    //
    // Tradeoffs:
    // - Acquisition & release calls always incur roundtrip to/frome kernel mode
    // - Underlying kernel object must be closed when no longer needed
    //      - handled automatically (but on a delayed basis) by GC/finalization mechanics 
    //
    // Kernel objects:
    // - Have an open and closed model
    // - Underlying must be closed, CloseHandle in Win32 terms
    // - If close is not called in your own code, the GC will eventually clean it up
    //   however it takes longer and incurs an overhead
    public static class Mutexes
    {
    }

    public class BankAccount
    {
        private double _balance;
        public readonly Mutex Lock = new Mutex();

        public void Credit(double amount)
        {
            // rather than use the lock keyword you call WaitOne on the Mutex object
            // can pass a timeout value to WaitOne, e.g.
            // Lock.WaitOne(5000) - only willing to wait 5 seconds
            // if the lock takes longer than 5 seconds to become available then it
            // returns false and the calling thread can try to acquire again when it
            // is next scheduled to do so
            if (Lock.WaitOne())
            {
                try
                {
                    _balance += amount;
                }
                finally
                {
                    // make sure to release mutex even if exception is raised
                    Lock.ReleaseMutex();
                }
            }
        }

        public void Debit(double amount)
        {
            if (Lock.WaitOne())
            {
                try
                {
                    _balance -= amount;
                }
                finally
                {
                    Lock.ReleaseMutex();
                }
            }
        }

        public void TransferFrom(BankAccount otherAccount, double amount)
        {

            // instead of calling WaitOne on both mutexs, we bundle them into an
            // array and call WaitAll passing in the array.
            // bundle up all the references to the locks we're interested in grabbing
            // and pass them to WaitAll.
            // offload the work to the CLR and wait for it to get us ownership of all
            // of the mutexs in the array, and do so in a manner that doesn't put us
            // at risk of deadlock.
            // either aquire both locks and return true, or return false if ownership
            // of all locks in the array can't be acquired
            Mutex[] locks = { this.Lock, otherAccount.Lock };

            // can also pass a timeout value to WaitAll
            // WaitHandle.WaitAll(locks, 1000) 
            if (WaitHandle.WaitAll(locks))
            {
                try
                {
                    otherAccount.Debit(amount);
                    this.Credit(amount);
                }
                finally
                {
                    // make sure to release mutexes in an exception safe manner
                    // WaitHandle does not supply a ReleaseMethod
                    foreach (var mutex in locks)
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
    }
}