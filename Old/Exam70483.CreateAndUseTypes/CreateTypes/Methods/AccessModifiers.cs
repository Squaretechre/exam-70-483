namespace Exam70483.CreateAndUseTypes.CreateTypes.Methods
{
    public class AccessModifiers
    {
        public void Hello()
        {
            // public - available everywhere
        }

        private void Shh()
        {
            // private - only available to code inside same class
        }

        internal void Hey()
        {
            // internal - only available to code in the same project
        }
    }
}