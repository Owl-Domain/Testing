namespace OwlDomain.Testing.Assertions.Tests;

[TestClass]
public sealed class NullAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region IsNull tests
	[TestMethod]
	public void IsNull_WithNullValue_DoesNothing()
	{
		// Arrange
		object? value = null;

		// Act
		IAssert result = AssertExtensions.IsNull(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNull_WithNonNullValue_CallsFail()
	{
		// Arrange
		object? value = new();

		// Act
		IAssert result = AssertExtensions.IsNull(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotNull tests
	[TestMethod]
	public void IsNotNull_WithNullValue_CallsFail()
	{
		// Arrange
		object? value = null;

		// Act
		IAssert result = AssertExtensions.IsNotNull(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNotNull_WithNonNullValue_DoesNothing()
	{
		// Arrange
		object? value = new();

		// Act
		IAssert result = AssertExtensions.IsNotNull(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
