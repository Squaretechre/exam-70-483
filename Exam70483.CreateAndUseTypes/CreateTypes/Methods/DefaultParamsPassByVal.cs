namespace Exam70483.CreateAndUseTypes.CreateTypes.Methods
{
    internal class DefaultParamsPassByVal
    {
        private readonly string _name;

        public DefaultParamsPassByVal()
        {
            _name = "Test";
        }

        public void DoSomething()
        {
            InternalThing(_name);
        }

        // method args are passed by value by default
        // for a reference type a copy of the memory address is copied
        private static void InternalThing(string name)
        {
            name = "some other name";
        }
    }
}