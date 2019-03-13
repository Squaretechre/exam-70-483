using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    internal class Dog
    {
        private readonly int _age;

        public Dog()
        {
        }

        public Dog(int age) : this(age, 4)
        {
        }

        public Dog(int age, int legs)
        {
            _age = age;
            NumberOfLegs = legs;
        }

        public string Name { get; set; }
        public int NumberOfLegs { get; set; }

        private string Speak(string message)
        {
            return $"{message.ToUpper()}!";
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var lassie = new Dog(100)
            {
                Name = "Lassie"
            };

            // With reflection
            var dog = (Dog)Activator.CreateInstance(typeof(Dog));
            var properties = typeof(Dog).GetProperties();
            var numberOfLegsProperty = properties[1];

            var anotherDog = Activator.CreateInstance<Dog>();

            // Or
            var numberOfLegsProperty2 = properties.First(p => p.Name.Equals("NumberOfLegs"));

            numberOfLegsProperty.SetValue(dog, 3, null);

            Console.WriteLine(dog.NumberOfLegs);

            // Use reflection to invoke different constructors
            var defaultConstructor = typeof(Dog).GetConstructor(new Type[0]);
            var ageConstructor = typeof(Dog).GetConstructor(new[] { typeof(int) });

            var defaultDog = (Dog)defaultConstructor.Invoke(null);
            Console.WriteLine(defaultDog.NumberOfLegs);

            var ageDog = (Dog)ageConstructor.Invoke(new object[] { 5 });
            Console.WriteLine(ageDog.NumberOfLegs);

            Console.WriteLine(lassie.GetPrivateField<int>("_age"));
            Console.WriteLine(lassie.InvokePrivateMethod<string>("Speak", new[] { "hello" }));
            Console.ReadKey();
        }
    }

    public static class ObjectExtensions
    {
        public static T InvokePrivateMethod<T>(this object anObject, string methodName, object[] args)
        {
            var type = anObject.GetType();
            var method = type
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(m => m.Name.Equals(methodName));

            return (T)method.Invoke(anObject, args);
        }

        public static T GetPrivateField<T>(this object anObject, string fieldName)
        {
            return (T)anObject
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(t => t.Name.Equals(fieldName))
                .GetValue(anObject);
        }
    }
}