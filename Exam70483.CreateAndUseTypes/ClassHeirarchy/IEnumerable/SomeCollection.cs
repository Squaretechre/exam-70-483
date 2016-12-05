using System.Collections;
using System.Collections.Generic;

namespace Exam70483.CreateAndUseTypes.ClassHeirarchy.IEnumerable
{
    // types implementing IEnumerable can be used in foreach loops
    public class SomeCollection : System.Collections.IEnumerable
    {
        private List<string> _things;

        public SomeCollection()
        {
            _things = new List<string>
            {
                "cat",
                "dog",
                "owl",
                "cow",
                "satanic leaf-tailed gecko"
            };
        }

        public IEnumerator GetEnumerator()
        {
            return _things.GetEnumerator();
        }
    }

    public class Picker
    {
        public void Pick()
        {
            foreach (var thing in new SomeCollection())
            {
            }
        }
    }
}