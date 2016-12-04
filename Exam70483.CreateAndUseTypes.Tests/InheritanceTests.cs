using Exam70483.CreateAndUseTypes.CreateTypes.Classes;
using NUnit.Framework;

namespace Exam70483.CreateAndUseTypes.Tests
{
    [TestFixture]
    public class InheritanceTests
    {
        [Test]
        public void SubTypeShouldCallSuperTypeShadowedMethodWhenDowncast()
        {
            Father person = new Son("The Father's son");
            var actual = person.PlaceInHierarchy();
            const string expected = "supertype";
            Assert.That(actual, Is.EqualTo(expected)); 
        }

        [Test]
        public void SubTypeShouldInvokeOwnImplementationOfShadowedSupertypeMethod()
        {
            Son person = new Son("The Father's son");
            var actual = person.PlaceInHierarchy();
            const string expected = "subtype";
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}