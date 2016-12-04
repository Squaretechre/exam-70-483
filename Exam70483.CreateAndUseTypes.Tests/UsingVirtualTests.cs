using Exam70483.CreateAndUseTypes.CreateTypes.Classes.UsingVirtual;
using NUnit.Framework;

namespace Exam70483.CreateAndUseTypes.Tests
{
    [TestFixture]
    public class UsingVirtualTests
    {
        [Test]
        public void ShouldInvokeDerivedTypesImplementationWhenAssignedToSuperType()
        {
            Vehicle vehicle = new Car();
            const string expected = "wheel";
            var actual = vehicle.SteeringMechanism();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AbstractVehicleSteeringMechanismShouldBeUndefined()
        {
            Vehicle vehicle = new Vehicle();
            const string expected = "undefined";
            var actual = vehicle.SteeringMechanism();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}