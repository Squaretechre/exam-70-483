namespace Exam70483.DebugAppsAndImplementSecurity.ManageAssemblies
{
    internal class AboutAssemblies
    {
        public void Method()
        {
            // assemblies are .exe or .dll files
            // contain metadata about all the types inside,
            // i.e. the names of the types and what methods they have

            // common .NET assemblies are put into the Global Assembly Cache (GAC)
            // this is a central location to store assemblies for a machine:
            // C:\Windows\assembly

            // must load an assembly into memory before using the types inside
            // easy approach - reference the assembly in visual studio

            // mscorlib does not appear in references but does in object browser
        }
    }
}