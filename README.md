# MitSharp

Collection of some C# classes and utilities I built for myself

## MitSharp.Testing

It contains some utilities that can be used for testing

### TestDataBuilder<T>

To create objects of type `T` for testing using the builder pattern, this generic object can be used to reduce the common boilerplate of writing a builder for your type.

Example usage:

Say you have a class called `Address` which looks like this:

```cs
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public ZipCode { get; set; }
}
```

Now we can use it in the following way:

```cs
// Step 1: Create a builder object with empty/default values for the class
var addressBuilder = TestDataBuilder<Address>.CreateWithDefault(new Address("", "", new ZipCode())); // can also use the constructor

// Step 2: To create objects with specific values
var address = addressBuilder.Select(a =>
{
    a.Street = "SomeTestValue";
    return a;
}).Build();
```

For more details, [read this blog post](https://blog.ploeh.dk/2017/08/21/generalised-test-data-builder/).

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
