Testing.MSTest
===

The test framework adapter package for
[MSTest](https://github.com/microsoft/testfx)
in the 
[OwlDomain.Testing](https://github.com/Owl-Domain/Testing)
framework. 

This package only provides the test framework adapter, make sure
to reference the package with the assertion methods as well.



## Usage

The optimal way to use these libraries is by using
[global usings](https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/using-directive#global-modifier).
For the MSTest adapter that would look like this:
```csharp
global using Assert = OwlDomain.Testing.MSTest.Assert;
global using OwlDomain.Testing.Assertions;
```
The first using helps to prevent ambiguity as MSTest also provides an `Assert` class, the second
using will allow you to access any of the assert extensions methods anywhere in your tests project.

After that, you can call the assertion methods like this:
```csharp
// Marks the test as failed if the value is not true.
Assert.That.IsTrue(value);

// Marks the test as inconclusive if the value is not true.
Assert.IsConclusiveIf.IsTrue(value);
```



## License

This project (the source, and the release files, e.t.c) is release under the [OwlDomain License](/license.md).