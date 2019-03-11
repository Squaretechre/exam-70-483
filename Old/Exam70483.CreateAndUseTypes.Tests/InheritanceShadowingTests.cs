using Exam70483.CreateAndUseTypes.CreateTypes.Classes.InheritanceShadowing;
using NUnit.Framework;

namespace Exam70483.CreateAndUseTypes.Tests
{
    [TestFixture]
    public class InheritanceShadowingTests
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
            var person = new Son("The Father's son");
            var actual = person.PlaceInHierarchy();
            const string expected = "subtype";
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}