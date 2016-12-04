using Exam70483.CreateAndUseTypes.CreateTypes.Classes.InheritanceShadowing;

namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes.UsingVirtual
{
    internal class UsingVirtual
    {
        public void CompileTimeVersusRuntime()
        {
            // without any other information to go off, the C# compiler will use the 
            // implementation of a method found in the the type any types are downcast to
            // without virtual = determined at compile time.
            Father person = new Son("the son");
            var placeInClassHierarchy = person.PlaceInHierarchy();
            
            // placeInClassHierarchy will be equal to "supertype" because the C# compiler
            // will generate code to use the implementation of "PlaceInHierarchy" found in
            // the Father class. The "PlaceInHierarchy" method is not marked with the virtual
            // keyword, so the compiler does not know any better at compile time.

            // in the below example, because the "SteeringMechanism" method in the Vehicle class
            // is marked as virtual, the C# compiler will generate code to instruct the runtime
            // to use the implementation found on the Car class at runtime.
            // virtual = determined by type of object at runtime.
            Vehicle vehicle = new Car();
            var steeringMechanism = vehicle.SteeringMechanism();

        }
    }
}