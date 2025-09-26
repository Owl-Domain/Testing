namespace OwlDomain.Testing.Assertions.Tests.NumericalAsserts.DeltaEquality;

[TestClass]
public sealed class DeltaEqualityAssertSByteTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region AreEqual tests
	[TestMethod]
	public void AreEqual_Nullable_WithinDelta_DoesNothing()
	{
		// Arrange
		sbyte? value = 5;
		sbyte? expected = 10;
		sbyte? delta = 10;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreEqual_Nullable_OutsideDelta_CallsFail()
	{
		// Arrange
		sbyte? value = 5;
		sbyte? expected = 10;
		sbyte? delta = 1;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreEqual_NoneNullable_WithinDelta_DoesNothing()
	{
		// Arrange
		sbyte value = 5;
		sbyte expected = 10;
		sbyte delta = 10;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreEqual_NoneNullable_OutsideDelta_CallsFail()
	{
		// Arrange
		sbyte value = 5;
		sbyte expected = 10;
		sbyte delta = 1;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region AreNotEqual tests
	[TestMethod]
	public void AreNotEqual_Nullable_WithinDelta_CallsFail()
	{
		// Arrange
		sbyte? value = 5;
		sbyte? expected = 10;
		sbyte? delta = 10;

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotEqual_Nullable_OutsideDelta_DoesNothing()
	{
		// Arrange
		sbyte? value = 5;
		sbyte? expected = 10;
		sbyte? delta = 1;

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotEqual_NoneNullable_WithinDelta_CallsFail()
	{
		// Arrange
		sbyte value = 5;
		sbyte expected = 10;
		sbyte delta = 10;

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotEqual_NoneNullable_OutsideDelta_DoesNothing()
	{
		// Arrange
		sbyte value = 5;
		sbyte expected = 10;
		sbyte delta = 1;

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, delta);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
