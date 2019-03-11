using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.ValueTypes.Enums
{
    internal class UsingStringComparison
    {
        public void Method()
        {
            const string name1 = "bill";
            const string name2 = "ben";

            // using the built in enum StringComparison
            // equals method will not accept an int for the comparison type
            // as the arg is of type StringComparison
            var areEqual = name1.Equals(name2, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}