# MitSharp

Collection of some C# classes and utilities I built for myself

## MitSharp.Utilities

It contains some utilities object models etc to solve some common issues.

### GenericSingleton

This can be used to create a singleton object from any type which can be used across the codebase. This singleton is also testable and can be used to replace the type instance with a mocked type without changing the consuming code. Here's how to use it:

Say you have a type called `SomeService` which implements an interface `ISomeService`. You can create a singleton for this service like:

```cs
public SomeServiceSingleton : GenericSingleton<ISomeService, SomeService>
{
}
```

and then can use it like:

```cs
var someService = SomeServiceSingleton.Instance;
```

For **Testing**, you can use the `SetInstance` method which can be used to replace the instance with a mocked instance, like:

```cs
// In TestSetup
var mockedSomeService = new Mock<ISomeService>();
SomeServiceSingleton.SetInstance(mockedSomeService.Object);

// Now the tests for code consuming the SomeServiceSingleton can work without any changes.
```
