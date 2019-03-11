# Classes and Structs #

- A class or struct defines the template for an object
- A class represents a reference type
- A struct represents a value type
- Reference and value imply memory strategies
- Instance of a class is reference type which is a pointer to where the object is on the heap
- References can refer to the same object

## When to use Structs ##

Use structs if:
- Instances of the type are small
- The struct is commonly embedded in another type
- The struct logically represents a single value
- The values don't change (immutable)
- It is rarely "boxed"
  - This is a performance consideration
  - I.e. doing a lot of computationally expensive activities, the abstraction of having a reference type introduces addtional steps if you want to access and manipulate those properties. For math computation structs provide faster access and will be quicker without this overhead.
  - Potentially memory concern if creating many structs in a loop

Note: structs can have performance benefits in computational intensive applications.

## Class ##

Classes can optionally be declared as:
- **Static** - cannot never be instantiated
- **Abstract** - incomplete class; must be completed in a derived class
- **Sealed** - cannot be inherited from
- **Partial** - one class definition spread across n files

- **Public** - can be used by anyone
- **Private** - can only be used within context of containing class and not in derived classes
- **Protected** - can only be used within containing class and derived classes
- **Internal** - can be used by anyone in the same assembly, scoped to a project

Default method parameters cannot preced those that are required.
Method signature = scope + return type + name + parameter types.

## Inheritance ##

Classes can optionally be delcare as:
- **Static** - cannot never be instantiated
- **Abstract** - incomplete class; must be completed in a derived class
- **Sealed** - cannot be inherited from

Virtual methods:
- Virtual methods have implementations
- They can be overriden in derived classes

## Casting ##

Casting changes the publicly exposed shape of the object but not what the object actually is.

## Boxing ##

- Boxing is the act of converting a value type to a reference type.
- Unboxing is the reverse and requires a cast.
- Boxing / Unboxing copies the value.
- Boxing is computationally expensive, avoid repetition
- Generics helps avoid these scenarios

## Events ##

Events raised as communication mechanism.
EventHandler defined to handle raised events.
Raised after something has happened.

If no subscribers are registered to handle event, null reference exception is thrown.
Event is a list of methods that need to be raised back.
Pressing tab after += when subscribing to an event will scaffold the delegate event handler method.