using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.ExtensionMethods
{
    // define extension methods using a static class
    public static class DateTimeExtensions
    {
        // methods are marked as static with the first argument being the "this" keyword
        // followed by the type to be extended
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }
}