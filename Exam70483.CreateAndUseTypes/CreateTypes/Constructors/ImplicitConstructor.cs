using System.Collections.Generic;

namespace Exam70483.CreateAndUseTypes.CreateTypes.Constructors
{
    public class ImplicitConstructor
    {
        // implicit constructor will be used as non defined

        // field initializer syntax
        private readonly List<string> _privateThings = new List<string>();

        public void TakeThing(string thing)
        {
            _privateThings.Add(thing);
        }
    }
}