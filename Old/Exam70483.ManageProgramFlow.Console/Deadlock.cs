namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Deadlock
    // Deadlock can occur whenever a hold-and-wait situation is possible
    // - while holding one lock, a thread attempts to acquire another lock
    //
    // Note that the above is rife with caveats:
    // - Deadlock "can" occur (but won't necessarily occur)
    //      - requires 2 or more threads competing for the same set of locks
    // - Deadlock is "possible" (but not necessarily probable)
    //      - probability increases as # of threads/processors/cores increases
    // - Deadlock "may" only be temporary
    //      - if timeouts are used in all lock acquisitions calls
    //
    // The possiblity of deadlock has to be recognised when you have code written
    // to acquire multiple locks using seperate operations.
    // Running your code and seeing it work doesn't mean there isn't a bug lurking
    //
    //
    //                    
    //             1________ [ Resource A ] ________3
    //            |                                  |
    //      [ Thread X ]                        [ Thead Y ]
    //            |                                  |
    //            |4________               _________2|
    //                       [ Resource B ]
    //
    // Deadlock Scenario:
    // - 1. Thread X acquires lock protecting resource A       - lock owner = X
    // - 2. Thread Y acquires lock protecting resource B       - lock owner = Y
    // - 3. Thread Y blocks trying to acquire lock protecting resource A
    // - 4. Thread X blocks trying to acquire lock protecting resource B
    // = deadlock

    public class Deadlock
    {
    }
}