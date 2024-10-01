Testing
===

A testing library which provides easily extensible assertions that can be used in test projects.

The main purpose of this library is to provide a unified way of calling the assertion
and to provide the same assertion methods for different outcomes, e.g. a test failing or
a test being inconclusive.



## Structure

This project is split into 3 areas: the base library, the assertions library, and the
test framework adapters.

- Base library - This library contains the `IAssert` interface that all the assertion
  extension methods are	expected to be based on, along with the `FormattingHelper` static 
  class which can be used to normalise and format the arguments used for the test result output.

- Assertions library - This library contains all of the provided assertion extension
  methods, it is separated from OwlDomain.Testing.Base so that you can fully replace 
  all of the assertion methods with your own custom ones.

- Test framework adapters - The purpose of these adapters is to provide implementations for
  the `IAssert` interface and a way to access them.

The project has been split up in this manner to make it easy to add/replace the assertion
methods, as well as making it extremely easy to create new test framework adapters.



## Currently supported test framework adapters

- OwlDomain.Testing.MSTest for [MSTest](https://github.com/microsoft/testfx) >= 3.0.0



## Installation

1. Pick out which adapter you want to use from the list above.
2. Download the latest release files for the base library, the assertions library
   and the adapter that you chose and add them to a 
   [local NuGet feed](https://learn.microsoft.com/nuget/hosting-packages/local-feeds), or 
   get them from the official [nuget.org](https://www.nuget.org/packages/OwlDomain.Polyease/) source.
3. Reference the packages from your .NET tests project. 

In C# and for the MSTest adapter, that would look like this:
```csproj
<ItemGroup>
  <PackageReference Include="OwlDomain.Testing.Assertions" Version="1.2.0" />
  <PackageReference Include="OwlDomain.Testing.MSTest" Version="1.0.0" />
</ItemGroup>
```
Remember to add any other dependencies that the testing framework requires as the adapter
only references the bare minimum it needs to in order to function.



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
(this will depend on the adapter that you chose, but all of the supported adapters are/will be similar)

The assertion methods in the `OwlDomain.Testing.Assertions` library also makes use of the
[CallerArgumentExpressionAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute)
and the 
[CallerLineNumberAttribute](https://learn.microsoft.com/dotnet/api/system.runtime.compilerservices.callerlinenumberattribute)
to provide extra information in the test result output, meaning that if you have
code like this (the numbers on the left representing the line numbers):
```csharp
1 // Act
2 bool result = ...;
3 
4 // Assert
5 Assert.That.IsTrue(result);
```

Then if the test fails (meaning that the `result` was false) the test output would look like this:
```
"result" was expected to be true, but it was false instead.
Line: 5
```

Assertion methods can also be chained in a manner like so:
```csharp
bool result1 = ...;
bool result2 = ...;

Assert.That
   .IsTrue(result1)
   .IsTrue(result2);
```



## Contributions

Code contributions will not be accepted, however feel free to provide feedback / suggestions 
by creating a [new issue](https://github.com/Owl-Domain/Testing/issues/new), or look at 
the [existing issues](https://github.com/Owl-Domain/Testing/issues?q=) to see if your
concern / suggestion has already been raised.



## License

This project (the source, and the release files, e.t.c) is release under the [OwlDomain License](/license.md).