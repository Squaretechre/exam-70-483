using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common
{
    public class Print
    {
        private const string NewLine = "\n";

        private static void RunExample(Expression<Action> example)
        {
            var methodCallExpression = (MethodCallExpression) example.Body;
            var methodName = methodCallExpression.Method.Name;
            PrintSeparatorWithTitle(methodName);
            example.Compile()();
        }

        public static void Examples(params Expression<Action>[] examples)
        {
            examples.ToList().ForEach(RunExample);
        }

        public static void PrintSeparatorWithTitle(string title)
        {
            const string separatingLine = "----------------------------------------";
            Console.WriteLine(NewLine);
            Console.WriteLine($"{separatingLine} {NewLine}");
            Console.WriteLine($"{title} {NewLine}");
            Console.WriteLine($"{separatingLine}");
            Console.WriteLine(NewLine);
        }

        public static void Finished(string message = "Finished processing. Press any key to end.")
        {
            Console.WriteLine(NewLine);
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}