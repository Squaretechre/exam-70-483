namespace Generics
{
    public class Animal<T> where T : Offspring
    {
        public T Offspring { get; set; }
    }

    public abstract class Offspring { }
    public class Egg : Offspring { }
    public class Piglet : Offspring { }

    class Program
    {
        static void Main(string[] args)
        {
            var bird = new Animal<Egg>();
            var pig = new Animal<Piglet>();
        }
    }
}
