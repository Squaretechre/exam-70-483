using System;

namespace Exam70483.ManageProgramFlow.ExceptionHandling
{
    public class ThrowException
    {
        public ThrowException(string name)
        {
            // an ArgumentNullException will be thrown up the stack until
            // it is caught by an exception handler.
            // every time a method is called it is put onto the stack, when it
            // finishes it is taken off.
            // this way we can see in the stack trace which method called what.
            // older calls are further down the stack in the exception message.

            // throw is a jumping statement. anything after the throw statement
            // will not be executed and we'll jump back to some earlier point
            // in the code the exception caught and handled.
            if (name == null) throw new ArgumentNullException(nameof(name));

            // some common exceptions:
            // DivideByZeroException
            // IndexOutOfRangeException
            // ArgumentNullException
            // NullReferenceException
            // InvalidOperationException
            // NotImplementedException

            // classes in the .NET framework also document what exceptions they might throw.
            // can be viewed in intellisense when viewing a classes list of methods.
        }
    }
}