using System.Collections.Generic;

namespace Exam70483.ManageProgramFlow.ProgramFlow
{
    internal class ForEachLoop
    {
        public void Method()
        {
            var things = new List<string>()
            {
                "cat",
                "sat",
                "mat"
            };

            foreach (var thing in things)
            {
                if(thing.Equals("mat")) continue;   // don't even bother with the following code, continue to next iteration
                if (thing.Equals("sat")) break;     // jump out of the loop all together and stop iterating
            }
        }
    }
}