using System;
using System.Runtime.Serialization;

namespace Exam70483.ManageProgramFlow.ExceptionHandling
{
    // custom exceptions should be used to throw exceptions which are more descriptive
    // of your business domain.
    // should inherit from Exception and have the "Exception" suffix in it's name
    internal class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}