using System;

namespace NewVirtualOverride
{
    internal class BaseClass
    {
        internal virtual void Name()
        {
            Console.WriteLine("BaseClass");
        }
    }

    internal class DerivedOverride : BaseClass
    {
        internal override void Name()
        {
            Console.WriteLine("DerivedOverride");
        }
    }

    internal class DerivedNew : BaseClass
    {
        internal new void Name()
        {
            Console.WriteLine("New");
        }
    }

    internal class DerivedOverwrite : BaseClass
    {
        internal void Name()
        {
            Console.WriteLine("Overwrite");
        }
    }

    class Program
    {
        public static void Main()
        {
            var baseClass = new BaseClass();
            var derivedOverride = new DerivedOverride();
            var derivedNew = new DerivedNew();
            var derivedOverwrite = new DerivedOverwrite();

            baseClass.Name();
            derivedOverride.Name();
            derivedNew.Name();
            derivedOverwrite.Name();

            Console.WriteLine("\nAfter casting to BaseClass:\n");

            baseClass.Name();
            ((BaseClass) derivedOverride).Name();
            ((BaseClass) derivedNew).Name();
            ((BaseClass) derivedOverwrite).Name();

            Console.ReadLine();

            var type = typeof(BaseClass);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.Assembly);

            Console.ReadKey();
        }
    }
}
