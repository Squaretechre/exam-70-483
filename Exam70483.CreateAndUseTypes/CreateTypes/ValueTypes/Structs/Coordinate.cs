namespace Exam70483.CreateAndUseTypes.CreateTypes.ValueTypes.Structs
{
    // structs are meant for special cases where you need to write an abstraction
    // that represents a single value, i.e. a datetime represents a single value.
    // a datetime is a single value that we can reason about, a point in time.
    // integers are obvious value types as they represent single values.
    // other examples, points in space, currency amounts.
    // all small single, single value concepts.
    // want structs to be small as they are value types and will be copied often.
    // common structs:
    // DateTime
    // int (Int32)
    internal struct Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}