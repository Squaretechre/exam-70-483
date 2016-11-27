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

            // string is also an immutable struct
            const string name = " bobby conn ";
            name.Trim();
            
            // ^ name still contains whitespace
        }
    }
}