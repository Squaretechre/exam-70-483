namespace CreateAndUseTypes
{
    class Boxing
    {
        void Foo()
        {
            int count = 1;

            // The value of count is copied and boxed
            object countObject = count;

            count += 1; // countObject is still 1

            // The value of countObject (1) is unboxed and copied to count
            count = (int) countObject;
        }
    }
}
