namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes.UsingVirtual
{
    public class Vehicle
    {
        public virtual string SteeringMechanism()
        {
            return "undefined";
        }
    }

    public class Car : Vehicle
    {
        public override string SteeringMechanism()
        {
            return "wheel";
        }
    }
}