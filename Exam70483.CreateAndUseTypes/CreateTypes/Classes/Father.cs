using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes
{
    public class Father
    {
        protected readonly string Name;

        public Father(string name)
        {
            Name = name;
        }

        public void SayName()
        {
            Console.WriteLine(Name);
        }

        public string PlaceInHierarchy()
        {
            return "supertype";
        }
    }
}