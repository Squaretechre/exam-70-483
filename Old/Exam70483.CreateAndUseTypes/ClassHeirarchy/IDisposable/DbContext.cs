namespace Exam70483.CreateAndUseTypes.ClassHeirarchy.IDisposable
{
    // any objects implementing IDisposable need some help cleaning up
    // may open files, create a db connection, talk to hardware
    // implement IDisposable to ensure resources are properly cleaned up
    public class DbContext : System.IDisposable
    {
        public void Dispose()
        {
            // ensure dbconnection is closed
        }
    }

    public class MemberStore
    {
        public void Add(string name)
        {
            using (var context = new DbContext())
            {
               // do something with the dbcontext and let the using statement
               // call Dispose after we're done to release the resource
               // this works by effectively setting up a try / finally block 
            }
        }
    }
}