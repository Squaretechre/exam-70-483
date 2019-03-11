using System;

namespace Exam70483.DelegatesAndEvents
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person("George");

            // single assignment
            // a delegate can be assigned to
            // it can also handle multi-cast assignment
            // also do not need to include the instantiation of the delegate
            // assigning a new delegate instance will wipe out previous registrations
            // events prevent this scenario
            person.NameChangedDelegate = new NameChangedDelegate(OnNameChangedEvent);
            person.Name = "James";

            var person2 = new Person("Jaws");

            // multi-cast assignment
            // events can't be assigned to
            // person2.NameChangeEvent = new NameChangedDelegate(OnNameChangedEvent)
            // ^ will not compile
            // events stop subscribers conflicting with each other
            person2.NameChangedEvent += OnNameChangedEvent;
            person2.NameChangedEvent += OnNameChangedEvent;
            person2.NameChangedEvent += OnNameChangedEventCapital;

            // OnNameChangedEvent is registered twice above, the -= syntax
            // removes one of those registrations
            person2.NameChangedEvent -= OnNameChangedEvent;
            person2.NameNotChangedEvent += OnNameNotChangedEvent;

            // person2.NameChangedEvent = new NameChangedDelegate(OnNameChangedEvent);
            person2.Name = "Odd Job";
            person2.Name = "Moneypenny";

            // this will fire the NameNotChangedEvent
            person2.Name = "Moneypenny";

            Console.ReadKey();
        }

        // these event handlers do not use the standardised format for event arguments
        private static void OnNameChangedEvent(string oldvalue, string newvalue)
        {
            Console.WriteLine($"Changed name from {oldvalue} to {newvalue}");
        }

        private static void OnNameChangedEventCapital(string oldvalue, string newvalue)
        {
            var message = $"Changed name from {oldvalue.ToUpper()} to {newvalue.ToUpper()}";
            Console.WriteLine(message);
        }

        // this event handler does use the standard format for event arguments
        private static void OnNameNotChangedEvent(object sender, NameNotChangedEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}