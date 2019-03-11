using System;
using System.Collections.Generic;

namespace Exam70483.ImplementDataAccess.UsingLINQ
{
    public static class LinqLikeExtensions
    {
        // example of recreating a filter method using a delegate type
        // no need to create a delegate every time as the Func type is more flexible
        //public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, FilterDelegate<T> predicate)
        //{
        //    foreach (var item in input)
        //    {
        //        if(predicate(item)) yield return item;
        //    } 
        //}

        // alternative signature that uses a Func rather than a Delegate
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Func<T, bool> predicate)
        {
            foreach (var item in input)
                if (predicate(item)) yield return item;
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
            var beginningWithLAnonymous = cities.Filter(delegate(string item) { return item.StartsWith("L"); });

            // using a lamda expression
            // the lambda produces the exact same delegate
            var beginningWithLLambda = cities.Filter(c => c.StartsWith("L"));

            // using a func
            // the last parameter of a func is the return type, all before at the inputs
            Func<string, bool> predicate = item => item.StartsWith("L");

            var beginningWithLFunc = cities.Filter(predicate);

            // func takes from 1 to 16 generic type parameters
            // parameters are required for a func's args if you have zero, or 2+
            // they are not required when there is one parameter, e.g
            Func<int, int, int> add = (x, y) => x + y;

            // actions take parameters but do not return anything
            Action<int> print = x => Console.WriteLine(x);
        }

        public bool FilterStringBeginsWithL(string item)
        {
            return item.StartsWith("L");
        }
    }
}