namespace OwlDomain.Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public sealed class IsBetweenAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region IsBetween tests
	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_AllNullable_WithValueInRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(-1, 0, 10, DisplayName = "Below minimum")]
	[DataRow(11, 0, 10, DisplayName = "Above maximum")]
	[TestMethod]
	public void IsBetween_AllNullable_WithValueOutsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_NoneNullable_WithValueInRange_DoesNothing(int value, int minimum, int maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(-1, 0, 10, DisplayName = "Below minimum")]
	[DataRow(11, 0, 10, DisplayName = "Above maximum")]
	[TestMethod]
	public void IsBetween_NoneNullable_WithValueOutsideRange_CallsFail(int value, int minimum, int maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}
	#endregion

	#region IsNotBetween tests
	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueInRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(-1, 0, 10, DisplayName = "Below minimum")]
	[DataRow(11, 0, 10, DisplayName = "Above maximum")]
	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueOutsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueInRange_CallsFail(int value, int minimum, int maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(-1, 0, 10, DisplayName = "Below minimum")]
	[DataRow(11, 0, 10, DisplayName = "Above maximum")]
	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueOutsideRange_DoesNothing(int value, int minimum, int maximum)
	{
		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}
	#endregion
}
