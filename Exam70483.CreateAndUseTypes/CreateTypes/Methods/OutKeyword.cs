namespace Exam70483.CreateAndUseTypes.CreateTypes.Methods
{
    internal class OutKeyword
    {
        public void SomeMethod()
        {
            // toAssignTo - has not been assigned to but can be used as an out arg
            int toAssignTo;
            HelperMethod(out toAssignTo);
        }

        // ref - will assume var passed in has been initialized somewhere
        // out - will not assume the above
        private static void HelperMethod(out int number)
        {
            // the out parameter must be assigned to before leaving the block
            // as the C# compiler does not assume that it has already been assigned to
            number = 2 * 2;
        }
    }
}