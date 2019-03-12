using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    // Parallel.For can be used to parallelize a for loop governed by a control variable.

    internal class ParallelFor
    {
        public static void Run()
        {
            var items = Enumerable.Range(0, 500).ToArray();
            var students = new List<Student>()
            {
                new Student() {Name = "Foo"},
                new Student() {Name = "Bar"},
                new Student() {Name = "Baz"},
            };

            Parallel.For(0, items.Length, i => { WorkOnItem(items[i]); });
            Parallel.For(0, students.Count, i =>
            {
                Console.WriteLine(students[i].Name);
            });

            Console.WriteLine("Finished processing. Press any key to end.");
            Console.ReadKey();
        }

        private static void WorkOnItem(int item)
        {
            Console.WriteLine("Started working on: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Finished working on: " + item);
        }

        private class Student
        {
            public string Name { get; set; }
        }
    }
}