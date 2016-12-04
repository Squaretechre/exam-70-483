using System;
using System.IO;

namespace Exam70483.ManageProgramFlow.ExceptionHandling
{
    public class TryCatch
    {
        public void Explanation()
        {
            try
            {
                throw new DivideByZeroException("Have this...");
            }
            catch (DivideByZeroException ex)
            {
                // when catching the CLR will go looking for the nearest catch statement
                // (in the execution of the program, NOT source code) with a matching exception type.
                // which ever stack frame is closes to the point of throwing an exception with the
                // matching type will handle it.
                // exceptions travel back up the call stack.
                // this block will ONLY handle DivideByZeroException, if the block above
                // threw anything else, it would not handle it
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                // finally blocks ALWAYS execute, even if an exception is caught
                // use finally block to clear up unmanaged connections, file streams, db connections
                // or just use a using statement with things that implement IDisposable

                // using - no matter how you leave a using block, through successful completion or an exception
                // the using statement will call dispose on the resource and close it
                // can actually only call using on objects that implement IDisposable

                // using - can use using on multiple resources before they are used in a block
                // this way both resources will be disposed of
                using (var stream = new FileStream("somefile.txt", FileMode.Open))
                using (var reader = new StreamReader(stream))
                {
                }
            }
        }
    }
}