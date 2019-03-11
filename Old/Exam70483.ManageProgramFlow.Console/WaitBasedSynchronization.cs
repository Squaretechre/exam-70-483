namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Wait-Based Thread Synchronization
    // - A "gentleman's agreement" or "handshake" model
    // Elements of the protocol:
    // - a shared resource is identified ("that array over there")
    //      - ^ something that will be access by multiple threads of execution
    // - a synchronization primitive/tool is agreed on (MonitorExample, mutex,...)
    // - an agreed upon instance of that primitive is identified
    //      - lock X guards file X, lock Y guards file Y, etc..
    //  - any thread wishing to access the resource agrees to:
    //      - 1. acquire ownership of the agreed upon synchronization primitive - a blocking operation
    //      - 2. access the shared resource only after ownership acquired
    //      - 3. release ownership of the synchronization primitive once access is complete
    //  
    // - KEY POINT: the protocol is voluntary
    //      - if 9/10 threads adhere to the protocol but one doesn't, there will be issues
    //
    // - The CLR doesn't understand the relationship between the locking primitive and what it guards
    //
    // Several wait-based synchronization primitives are availble in the CLR
    // - MonitorExample                            ----
    // - Mutex                                  |
    // - ReaderWriterLockSlim                   |---- classes in the System.Threading namespace
    // - ManualResetEvent, AutoResetEvent       |
    // - Semaphore                          ----
    //
    // The first 3 share the same basic usage model
    // - Make a function call to "acquire" ownership of the "lock"
    // - "Use" the shared resource the designated "lock" is meant to protect
    // - Make a function call to "release" "lock" ownership once no longer needed
    public static class WaitBasedSynchronization
    {
        public static void Run()
        {
            
        }
    }
}