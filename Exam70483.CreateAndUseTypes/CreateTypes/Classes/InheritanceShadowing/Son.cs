using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes.InheritanceShadowing
{
    public class Son : Father
    {
        public Son(string name) : base(name)
        {
        }

        public void SayName()
        {
            Console.WriteLine(Name.ToUpper()); 
        }

        public string PlaceInHierarchy()
        {
            return "subtype";
        }
    }
}