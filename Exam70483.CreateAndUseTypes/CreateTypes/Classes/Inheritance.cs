namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes
{
    public class Inheritance
    {
        public void Example()
        {
            Father person1 = new Father("Dad");
            Father person2 = new Son("Son");

            person1.SayName();
            person2.SayName();
          
        }
    }
}