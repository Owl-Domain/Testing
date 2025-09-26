namespace OwlDomain.Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreSameInstanceAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region AreSameInstance tests
	[TestMethod]
	public void AreSameInstance_WithBothInstancesNull_DoesNothing()
	{
		// Arrange
		object? value = null;
		object? expected = null;

		// Act
		IAssert result = AssertExtensions.AreSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreSameInstance_WithSameInstance_DoesNothing()
	{
		// Arrange
		object? value = new();

		// Act
		IAssert result = AssertExtensions.AreSameInstance(_assert, value, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreSameInstance_WithFirstInstanceNull_CallsFail()
	{
		// Arrange
		object? value = null;
		object? expected = new();

		// Act
		IAssert result = AssertExtensions.AreSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreSameInstance_WithSecondInstanceNull_CallsFail()
	{
		// Arrange
		object? value = new();
		object? expected = null;

		// Act
		IAssert result = AssertExtensions.AreSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreSameInstance_WithDifferenceInstances_CallsFail()
	{
		// Arrange
		object? value = new();
		object? expected = new();

		// Act
		IAssert result = AssertExtensions.AreSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region AreNotSameInstance tests
	[TestMethod]
	public void AreNotSameInstance_WithBothInstancesNull_CallsFail()
	{
		// Arrange
		object? value = null;
		object? expected = null;

		// Act
		IAssert result = AssertExtensions.AreNotSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotSameInstance_WithSameInstance_CallsFail()
	{
		// Arrange
		object? value = new();

		// Act
		IAssert result = AssertExtensions.AreNotSameInstance(_assert, value, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotSameInstance_WithFirstInstanceNull_DoesNothing()
	{
		// Arrange
		object? value = null;
		object? expected = new();

		// Act
		IAssert result = AssertExtensions.AreNotSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotSameInstance_WithSecondInstanceNull_DoesNothing()
	{
		// Arrange
		object? value = new();
		object? expected = null;

		// Act
		IAssert result = AssertExtensions.AreNotSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotSameInstance_WithDifferenceInstances_DoesNothing()
	{
		// Arrange
		object? value = new();
		object? expected = new();

		// Act
		IAssert result = AssertExtensions.AreNotSameInstance(_assert, value, expected);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
