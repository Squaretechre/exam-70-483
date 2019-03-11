using System;

namespace CreateAndUseTypes
{
    public class Trainer
    {
        void Operate()
        {
            var dog = new Poodle();
            dog.HasSpoken += Dog_HasSpoken;
        }

        private void Dog_HasSpoken(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    public partial class Dog
    {
        // Properties hold values
        public int Age { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public event EventHandler HasSpoken;

        // Only by this class
        private void Foo() { }

        // Only this and derived classes
        protected void Bar() { }

        // Only in this assembly
        internal void Baz() { }

        // Method signature = scope + return type + name + parameter types
        public void Speak(string what = "bark")
        {
            // If no subscribers are registered to handle event, null reference exception is thrown.
            HasSpoken?.Invoke(this, EventArgs.Empty);
        }

        // Default parameters cannot precede required parameters
        public void Speak(int times, string what = "bark")
        {
            // TODO
        }

        // Default parameters cannot precede required parameters
        public void Speak(int times, string what = "bark", bool sit = true)
        {
            // TODO
        }
    }

    public class Poodle : Dog
    {
        void x()
        {
            this.Speak("Woof");
            this.Speak(2,"Woof");

            // Use named arguments to target specific method
            this.Speak(2, sit:true);

            // Named arguments don't have to be called in the order they're defined
            this.Speak(2, sit: true, what: "bark");
        }
    }
}
