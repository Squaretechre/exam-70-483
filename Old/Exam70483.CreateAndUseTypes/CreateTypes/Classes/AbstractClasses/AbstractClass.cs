using System;

namespace Exam70483.CreateAndUseTypes.CreateTypes.Classes.AbstractClasses
{
    // abstract classes can not be instantiated
    // they must be inherited from and implemented by a concrete type
    public abstract class AbstractClass
    {
        public string About()
        {
            return "I come from the base class";
        }

        // can supply an overrideable implementation using virtual
        // use the override keyword to change implementation
        public virtual string TellMeSomething()
        {
            return "I'm an abstract class";
        }

        // abstract methods are inherently virtual
        // only provide method signature and no implementation
        // use the override keyword to implement
        public abstract string TellMeMore();
    }

    // only implements TellMeMore but uses base implementation of TellMeSomething
    public class NotSoAbstractPerson : AbstractClass
    {
        // using override keyword to implement 
        public override string TellMeMore()
        {
            return "oh hai!";
        }
    }

    // both overrides the virtual method in the base class
    // and provides an implementation for TellMeMore
    public class AnotherNotSoAbstractPerson : AbstractClass
    {
        public override string TellMeSomething()
        {
            return "I override all the things";
        }

        public override string TellMeMore()
        {
            return "who likes a good story about a bridge?";
        }
    }
}