using System;
using Exam70483.CreateAndUseTypes.CreateTypes.ExtensionMethods;
using NUnit.Framework;

namespace Exam70483.CreateAndUseTypes.Tests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void ShouldCalculateTheCorrectNumberOfDaysLeftInMonth()
        {
            var date = new DateTime(2016, 12, 21);
            const int expected = 10;
            var actual = date.DaysToEndOfMonth();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}