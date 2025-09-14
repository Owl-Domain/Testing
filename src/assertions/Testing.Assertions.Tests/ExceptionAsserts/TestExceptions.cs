namespace Testing.Assertions.Tests.ExceptionAsserts;

[ExcludeFromCodeCoverage]
public class TestException : Exception
{
	#region Constructors
	public TestException() { }
	public TestException(string? message) : base(message) { }
	public TestException(string? message, Exception? inner) : base(message, inner) { }
	#endregion
}

[ExcludeFromCodeCoverage]
public sealed class DerivedTestException : TestException
{
	#region Constructors
	public DerivedTestException() { }
	public DerivedTestException(string? message) : base(message) { }
	public DerivedTestException(string? message, Exception? inner) : base(message, inner) { }
	#endregion
}
