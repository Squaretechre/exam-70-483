using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    internal class ParallelLinq
    {
        public static void Run()
        {
            var people = new List<Person>
            {
                new Person {Name = "Alan", City = "Hull"},
                new Person {Name = "Beryl", City = "Seattle"},
                new Person {Name = "Charles", City = "London"},
                new Person {Name = "David", City = "Seattle"},
                new Person {Name = "Eddy", City = "Paris"},
                new Person {Name = "Fred", City = "Berlin"},
                new Person {Name = "Gordon", City = "Hull"},
                new Person {Name = "Henry", City = "Seattle"},
                new Person {Name = "Isaac", City = "Seattle"},
                new Person {Name = "James", City = ""},
                new Person {Name = "Jim", City = ""},
                new Person {Name = "Jeremy", City = ""}
            };

            Print.Examples(
                () => AsParallel(people),
                () => ForcedParallelism(people),
                () => AsOrdered(people),
                () => AsSequential(people),
                () => ForAll(people)
            );
            Print.Finished();
        }

        private static void ExceptionsInQueries(IEnumerable<Person> people)
        {
            try
            {
                var result =
                    from person in people.AsParallel()
                    where CheckCity(person.City)
                    select person;

                result.ForAll(person => Console.WriteLine(person.Name));
            }
            catch (AggregateException e)
            {
                foreach (var ex in e.InnerExceptions)
                    Console.WriteLine(ex.Message);
            }
        }

        private static bool CheckCity(string name)
        {
            if (name == "")
                throw new ArgumentException(name);

            return name.Equals("Seattle");
        }

        private static void ForAll(IEnumerable<Person> people)
        {
            var result =
                from person in people.AsParallel()
                where person.City == "Seattle"
                select person;

            result.ForAll(person => Console.WriteLine(person.Name));
        }

        private static void AsSequential(IEnumerable<Person> people)
        {
            var result = (
                from person in people.AsParallel()
                where person.City == "Seattle"
                orderby person.Name
                select new
                {
                    person.Name
                }
            ).AsSequential().Take(4);

            foreach (var person in result)
            {
                Console.WriteLine(person.Name);
            }
        }

        private static void AsOrdered(IEnumerable<Person> people)
        {
            var result =
                from person in people.AsParallel().AsOrdered()
                where person.City == "Seattle"
                select person;

            foreach (var person in result) Console.WriteLine(person.Name);
        }

        private static void ForcedParallelism(IEnumerable<Person> people)
        {
            var forcedParallelResult =
                from person in people.AsParallel()
                    .WithDegreeOfParallelism(4)
                    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                where person.City == "Seattle"
                select person;

            Parallel.ForEach(forcedParallelResult, person => Console.WriteLine(person.Name));
        }

        private static void AsParallel(IEnumerable<Person> people)
        {
            var result =
                from person in people.AsParallel()
                where person.City == "Seattle"
                select person;

            foreach (var person in result) Console.WriteLine(person.Name);
        }

        internal class Person
        {
            public string Name { get; set; }
            public string City { get; set; }
        }
    }
}