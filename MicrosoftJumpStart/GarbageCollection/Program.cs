using System.IO;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = "C:\test.txt";

            using (var file = File.Open(path, FileMode.Open))
            {
                // Do something with file
            }
        }
    }
}
