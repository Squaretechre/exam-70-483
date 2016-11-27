namespace Exam70483.DelegatesAndEvents
{
    public class Person
    {
        private string _name;

        // we hold a reference to the delegate method for the lifetime of the object
        // delegates are multi-cast delegates
        // change a plain delegate to an event by adding the event keyword
        // can't assign to an event and will be null if no listeners registered
        public event NameChangedDelegate NameChangedEvent;
        public NameChangedDelegate NameChangedDelegate;

        public event NameNotChangedDelegate NameNotChangedEvent;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                {
                    NameNotChangedEvent(this, new NameNotChangedEventArgs("Unable to update name"));
                    return;
                }

                // name changed has no idea which method will execute
                // it just invokes the delegate which is pointing to a method
                // elsewhere
                NameChangedEvent?.Invoke(_name, value);
                NameChangedDelegate?.Invoke(_name, value);
                _name = value;
            }
        }

        public Person(string name)
        {
            _name = name;
        }
    }
}