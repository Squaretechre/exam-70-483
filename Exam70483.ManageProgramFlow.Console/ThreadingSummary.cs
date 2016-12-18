namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    internal class ThreadingSummary
    {
        // Most resources are [not] meant to be accessed concurrently
        // - improper access yields race conditions and incorrect results
        //      - very difficult to detect, debug and fix
        //
        // Common solutions
        // - atomic updates of machine-word-sized values
        // - data partitioning
        // - wait-based synchronization (monitor, mutex, others)
        //
        // Beware
        // - critical sections
        // - race conditions
        // - deadlock
    }
}