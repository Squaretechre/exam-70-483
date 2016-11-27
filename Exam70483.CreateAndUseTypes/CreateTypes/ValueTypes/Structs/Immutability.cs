using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.ValueTypes.Structs
{
    internal class Immutability
    {
        public void Method()
        {
            // value types are immutable
            var date = new DateTime(2016, 11, 27);

            // even though DateTime exposes methods such as AddDays,
            // they do not mutate the original variable, rather a new updated
            // DateTime instance is returned
            date.AddDays(1);

            // ^ date is still equal to 27/11/16 as the returned DateTime wasn't assigned

            // string is a reference type, it is a reference that points to a sequence
            // of characters.
            // however whilst they are reference types, they are immutable and behave
            // in many ways like a value type
            const string name = " bobby conn ";
            name.Trim();
            
            // ^ name still contains whitespace
        }
    }
}