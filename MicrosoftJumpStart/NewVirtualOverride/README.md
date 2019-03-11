# Virtual #

Declares the intention that a method can be overriden by derived classes. It doesn't have to be overriden as there is already an implementation not marked as abstract.

- **Override** - Replace code block in base with overriden method. Overriden implementations will still be used even if a derived type is cast back to it's parent type. Overriden methods can however call the base implementation.
- **New** - Tells compiler to replace wholesale with a new unique implementation that has no relationship with the base implementation, cannot invoke the base implementation. Base implementation will be used if derived type is cast back to base type.
- *hiding* - Reimplementing a virtual method in a derived type without a keyword will *hide* the base implementation 