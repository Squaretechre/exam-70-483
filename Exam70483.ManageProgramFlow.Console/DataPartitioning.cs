namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    // Data Partitioning
    // Sometimes can partition data to orchestrate multi-threaded access
    // - Depends on the data or resources being operated on
    // - Requires problem-domain specific programming
    // - "You work on this while I work on that" model
    // - e.g. directory based file operations
    //
    //  T1      T2        
    //        | 
    //       o|
    //     /  |\
    //    o   | o
    //   / \  |  \
    //  o   o |   o
    //        |
    //
    // - e.g. array manipulations
    //
    // [][][][][][][][][][]
    //  \_______/\________/
    //      |         |
    //      T1        T2
    //
    // where T = thread
    // 
    // Here the threads are mutually exclusive and mutate different parts of the data
    // which can help to increase parallelisation
    //
    // Wait-Based Synchronization
    // - Sometimes threads need access to the same resource - can't partition
    //      - e.g. insert or delete node from a list while other thread/s are navigating it
    //      - e.g. multiple threads trying to manipulate the same file
    //
    // - Sometimes data dependencies prevent a partitioned approach
    //      - When the output from one thread is required as input to another
    //      - e.g. computing the Fibonacci sequence
    //          - sequence[0] = sequence[1] = 1
    //          - sequence[n] = sequence[n-1] + sequence[n-2]
    //
    // When a situation does not lend itself to data partitioning then it requires
    // a "wait-based" approach to synchronization
    // - i.e. thread may have to block until access is allowed
    internal static class DataPartitioning
    {
        public static void Run()
        {
            
        }
    }
}