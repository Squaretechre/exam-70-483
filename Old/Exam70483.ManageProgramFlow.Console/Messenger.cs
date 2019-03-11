using System;
using System.Threading;

namespace Exam70483.ManageProgramFlow.ConsoleApp
{
    internal class Messenger
    {
        private readonly string _message;

        public Messenger(string message)
        {
            _message = message;
        }

        public void DisplayMessage()
        {
            Console.WriteLine("[{0}] {1}", Thread.CurrentThread.ManagedThreadId, _message);
        }
    }
}