# Garbage Collection #

- In most cases, let the Garbage Collector do its thing
- For a periodic activity it may make sense to force the collector to run, i.e. a Windows Service

- `GC.Collect()`
- `GC.WaitForPendingFinalizers()`
- `GC.Collect()`

## IDisposable ##

Preemptively release resources prior to any garbage collection.

Implement `IDisposable` if:

- If an object consumes many resources when instantiated
- If you want to proactively free expensive resources but you don't want to force a full collection cycle 
- Implementing something expensive such as a stream or an outside resource

## Disposable Objects ##

- Some objects need explicit code to release resources
- The `IDisposable` interface marks that these types implement the `Dispose` method
- The simple dispose pattern works well for simple scenarios and sealed types
    - Use the advanced pattern in most cases

## Advanced Pattern ##

- Use for any non-trivial disposable object

```
    public AdvancedDemo : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SupressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Release managed resources
                // Other managed types that implement the dispose pattern
                // Call Dispose on these
            }
            // Release unmanaged resources
            // For example, set references to COM objects to null
        }

        // Finalizer
        ~AdvancedDemo()
        {
            Dispose(false);
        }
    }
```

## Dispose vs Close vs Stop ##

- Close
  - May be functionally the same as Dispose
  - May be a subset of Dispose functionality
- A closed object may be reopened
  - IDbConnection
- Stop is similar to Close
  - May be restarted
  - Time, etc.

## Memory Leaks ##

- Events can be a common source of memory leaks
  - Events can hold references to objects
  - Solution - unsubscribe from events proactively

## Weak References ##

- Weak references create a reference that the Garbage Collector ignores
- The Garbage Collector will assume an object is eligible for collection if it's only referred to by weak references
- To hold an object with only weak references, create a local variable referring to the weak reference value
  - This prevents collection until the local variable is out of scope  
