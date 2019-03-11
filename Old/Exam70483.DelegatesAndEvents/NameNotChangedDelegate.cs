using System;

namespace Exam70483.DelegatesAndEvents
{
    // the .NET standard way of declaring a delegate
    // the first parameter should the the object invoking the delegate
    // the second parameter is a object that holds the payload for the event
    public delegate void NameNotChangedDelegate(object sender, NameNotChangedEventArgs args);

    public class NameNotChangedEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public NameNotChangedEventArgs(string message)
        {
            Message = message;
        }
    }
}