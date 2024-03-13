Testing
===
A testing library which provides easily extensible assertions that can be used in test projects.

The main purpose of this library is to provide a unified way of calling the assertion
and to provide the same assertion methods for different outcomes, e.g. a test failing or
a test being inconclusive.



## Structure

This project is split into multiple components, the base library which provides
all the 


### Base library
This project is split into multiple components, the main component being the 
`OwlDomain.Testing` project, this project provides all the assertion methods
as extension methods on the `IAssert` interface, meaning that you can 
easily add your own assertions on top of that in the same manner.

The base library also provides a static `FormattingHelper` class with a single
static function `FormatArguments` which helps to normalise and format any arguments
for the test result messages. 

### Adapter libraries

After there each test framework can have it's own adapter library, which only has to 
provide the implementations for the `IAssert` interface, and a way to access them, 
for the `OwlDomain.Testing.MSTest` adapter library that looks something like this:
```csharp
using MSAssert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

public sealed class FailAssert : IAssert
{
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string message) => MSAssert.Fail(message);

   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      MSAssert.Fail(format, newArguments);
   }
}

public sealed class InconclusiveAssert : IAssert
{
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string message) => MSAssert.Inconclusive(message);

   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      MSAssert.Inconclusive(format, newArguments);
   }
}

public static class Assert
{
   /// <summary>An <see cref="IAssert"/> where failed assertions will result in the test being marked as failed.</summary>
   public static IAssert That { get; } = new FailAssert();

   /// <summary>An <see cref="IAssert"/> where failed assertions will result in the test being marked as inconclusive.</summary>
   public static IAssert IsConclusiveIf { get; } = new InconclusiveAssert();
}
```

This means that the same assertion methods can be used to mark the test as failed, or as inconclusive, 
with the usage looking something like this:
```csharp
// fails the test if the value is not true.
Assert.That.IsTrue(value);

// marks the test as inconclusive if the value is not true.
Assert.IsConclusiveIf.IsTrue(value);
```

The simplicity of the adapter library means that even though
[MSTest](https://github.com/microsoft/testfx)
is the only currently supported test framework, it is trivial
to add support for any test framework you want yourself.

## Currently supported test frameworks
- [MSTest](https://github.com/microsoft/testfx) >= 3.0.0



## Contributions

Code contributions will not be accepted, however feel free to provide feedback / suggestions 
by creating a [new issue](https://github.com/Owl-Domain/Testing/issues/new), or look at 
the [existing issues](https://github.com/Owl-Domain/Testing/issues?q=) to see if your
concern / suggestion has already been raised.



## License

This project is not currently under any license, all rights are reserved, however it will become more
permissive at a later date.