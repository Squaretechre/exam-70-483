# Manage Program Flow #

## Implement multithreading and asynchronous processing ##

- Use the Task Parallel library, including theParallel.For method
- PLINQ
- Tasks / create continuation tasks
- Spawn threads by using ThreadPool
- Unblock the UI
- Use async and await keywords
- Manage data by using concurrent collections

### Notes ###

#### The Task Parallel Library (TPL) ####

- Task is an abstraction of  aunit of work to be performed
- The TPL provides a range of resources that allow you to use tasks in an application
- `Task.Parallel` provides three methods that can be used to create applications that contain tasks that execute in parallel
- `Parallel.Invoke` accepts a number of `Action` delegates and creates a `Task` for each of them
- `Parallel.ForEach` performs a parallel implementatio of the foreach loop construction
- `Parallel.For` can be used to parallelize the execution of a for loop, which is governed by a control variable 
- `Parallel.For` and `Parallel.ForEach` accept an optional parameter of type `ParallelLoopState` that allows the code being iterated over to control the iteration process
- `Parallel.For` and `Parallel.ForEach` return a value of type `ParallelLoopResult` that can be used to determine whether or not a parallel loop has successfully completed
- `Stop` will prevent any iterations with an index value greater than the current index. Iterations with an index lower than the current index may not be performed
- `Break` ensures that all iterations with an index lower than the current iteration are guaranteed to be completed before the loop is ended
- Note that calling `Stop` on `ParallelLoopState` does not mean that the iterator will instantly stop any executing iterations.

#### Parallel LINQ (PLINQ) ####

- PLINQ can be used to allow elements of a query to execute in parallel
- The `AsParallel` method examines the query to determine if using a parallel version would speed it up. If so the query is broken into a number of processes which run concurrently
- If `AsParallel` can't decide whether parallelization would improve performance, the query is not executed in parallel   

##### Informing Parallelization #####

- Can use `WithExecutionMode(ParallelExecutionMode.ForceParallelism)` to force a query to execute in parallel
- Can use `WithDegreeOfParallelism(int)` to set the maximum number of processors for the query to execute on 
- A parallel query may produce output data in a different order from the input data
- `AsOrdered` does not prevent parallelization of a query but does organize the output so that it's in the same order as the original data. This can slow down the query
- `AsSequential` executes a query in order, whereas `AsOrdered` returns a sorted result but does not necessarily run the query in order

##### Iterating Query Elements Using ForAll #####

- `ForAll` can be used to iterate through all the elements in a query
- `ForAll` differs from foreach in that the iteration takes place in parallel and will start before the query is complete
- The parallel nature of `ForAll` means that the order of the output data will not reflect the ordering of the input data
- If any queries throw an exception an `AggregateException` will be thrown when the query is complete
- `AggregateException` contains a list a list, `InnerException`, of the exceptions thrown during the query 

## Manage multithreading ##

Synchronize resources; implement locking; cancel a long-running task; implement thread-safe methods to handle race conditions

## Implement program flow ##

Iterate across collection and array items; program decisions by using switch statements, if/then, and operators; evaluate expressions

## Create and implement events and callbacks ##

Create event handlers; subscribe to and unsubscribe from events; use built-in delegate types to create events; create delegates; lambda expressions; anonymous methods

## Implement exception handling ##

Handle exception types, including SQL exceptions, network exceptions, communication exceptions, network timeout exceptions; use catch statements; use base class of an exception; implement try-catchfinally blocks; throw exceptions; rethrow an exception; create custom exceptions; handle inner exceptions; handle aggregate exception