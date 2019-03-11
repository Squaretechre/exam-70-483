namespace Exam70483.CreateAndUseTypes.CreateTypes.Constructors
{
    internal class DefaultConstructor
    {
        public string Name { get; private set; }

        // ctor - can be used to generate default constructor
        public DefaultConstructor()
        {
            Name = "Immutable string set from default constructor";
        } 
            
    }
}