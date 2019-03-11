namespace Exam70483.CreateAndUseTypes.CreateTypes.Methods
{
    internal class RefKeyword
    {
        private Cat _cat1;
        private Cat _cat2;

        public RefKeyword()
        {
            _cat1 = new Cat("Mittens"); 
            _cat2 = _cat1;

            // at this point both cats point to the same object, mittens
            SetCat(_cat1);

            // after calling SetCat, because both _cat1 & _cat2 point to the same
            // object, by passing _cat1 into SetCat, both _cat1 & _cat2 both point
            // to the new Cat object, Mittens II

            SetCatRef(ref _cat2);
            // after setting _cat2 by ref only _cat2 has been updated.
            // rather than change the value of what lived at the memory address both
            // _cat1 & _cat2 pointed to, passing by ref actually updated the reference
            // held inside of the _cat2 variable.
            // _cat1 now points to Mittens II
            // _cat2 now points to Mystery Cat
        }

        public void SetCat(Cat cat)
        {
            cat = new Cat("Mittens II");
        }

        public void SetCatRef(ref Cat existingCat)
        {
            // because the existingCat is passed by ref, changing it to a new object
            // will not make all existing references to existingCat point to the new
            // object, rather it will change the one reference of the variable which
            // was passed into the methods argument when invoked. the calling Cat var
            // will have it's reference updated to where the new myster cat object lives 
            existingCat = new Cat("Mystery Cat");
        }

        // count will be passed by reference
        // rather than a copy being passed the memory address for count is passed
        // this can be updated so wherever count lives outside of the methods scope
        // will also update as it is pointing to the same variable
        public void SomeMethod(ref int count)
        {
            count = 42;
        }
    }

    public class Cat
    {
        public string Name { get; private set; }

        public Cat(string name)
        {
            Name = name;
        }
    }
}