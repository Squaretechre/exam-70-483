using System;
using System.Collections.Generic;

namespace Exam70483.ImplementDataAccess.UsingLINQ
{
    public static class LinqLikeExtensions
    {
        // example of recreating a filter method using a delegate type
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, FilterDelegate<T> predicate)
        {
            foreach (var item in input)
            {
                if(predicate(item)) yield return item;
            } 
        }
    }

    public delegate bool FilterDelegate<T>(T item);

    public class ExampleUsage
    {
        public void Main()
        {
            IEnumerable<string> cities = new[] {"London", "Paris", "Luxembourg"};

            // using a named method as the predicate
            var beginningWithLNamed = cities.Filter(FilterStringBeginsWithL);

            // using an anonymous delegate
            var beginningWithLAnonymous = cities.Filter(delegate(string item)
            {
                return item.StartsWith("L");
            });

            // using a lamda expression
            var beginningWithLLambda = cities.Filter(c => c.StartsWith("L"));
        }

        public bool FilterStringBeginsWithL(string item)
        {
            return item.StartsWith("L");
        }
    }
}