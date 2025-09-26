using NSubstitute.ReceivedExtensions;

namespace OwlDomain.Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public sealed class IsBetweenWithComparerAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	private readonly IComparer<int> _comparer = Substitute.For<IComparer<int>>();
	#endregion

	#region IsBetween tests
	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_AllNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Arrange
		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));

		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value.Value, minimum.Value);
		_comparer.Received(1).Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsBetween_AllNullable_WithValueBelowMinimum_CallsFail()
	{
		// Arrange
		int? value = -1;
		int? minimum = 0;
		int? maximum = 10;

		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));
		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value.Value, minimum.Value);
		_comparer.ReceivedAtMostOnce().Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsBetween_AllNullable_WithValueAboveMaximum_CallsFail()
	{
		// Arrange
		int? value = 11;
		int? minimum = 0;
		int? maximum = 10;

		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));
		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.ReceivedAtMostOnce().Compare(value.Value, minimum.Value);
		_comparer.Received(1).Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_NoneNullable_WithValueInsideRange_DoesNothing(int value, int minimum, int maximum)
	{
		// Arrange
		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));

		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value, minimum);
		_comparer.Received(1).Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsBetween_NoneNullable_WithValueBelowMinimum_CallsFail()
	{
		// Arrange
		int value = -1;
		int minimum = 0;
		int maximum = 10;

		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));
		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value, minimum);
		_comparer.ReceivedAtMostOnce().Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsBetween_NoneNullable_WithValueAboveMaximum_CallsFail()
	{
		// Arrange
		int value = 11;
		int minimum = 0;
		int maximum = 10;

		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));
		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.ReceivedAtMostOnce().Compare(value, minimum);
		_comparer.Received(1).Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}
	#endregion

	#region IsNotBetween tests
	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueInsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Arrange
		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));

		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.ReceivedAtMostOnce().Compare(value.Value, minimum.Value);
		_comparer.ReceivedAtMostOnce().Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueBelowMinimum_DoesNothing()
	{
		// Arrange
		int? value = -1;
		int? minimum = 0;
		int? maximum = 10;

		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));
		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.ReceivedAtMostOnce().Compare(value.Value, minimum.Value);
		_comparer.ReceivedAtMostOnce().Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueAboveMaximum_DoesNothing()
	{
		// Arrange
		int? value = 11;
		int? minimum = 0;
		int? maximum = 10;

		_comparer.Compare(value.Value, minimum.Value).Returns(value.Value.CompareTo(minimum.Value));
		_comparer.Compare(value.Value, maximum.Value).Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.ReceivedAtMostOnce().Compare(value.Value, minimum.Value);
		_comparer.ReceivedAtMostOnce().Compare(value.Value, maximum.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueInsideRange_CallsFail(int value, int minimum, int maximum)
	{
		// Arrange
		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));

		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.ReceivedAtMostOnce().Compare(value, minimum);
		_comparer.ReceivedAtMostOnce().Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueBelowMinimum_DoesNothing()
	{
		// Arrange
		int value = -1;
		int minimum = 0;
		int maximum = 10;

		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));
		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.ReceivedAtMostOnce().Compare(value, minimum);
		_comparer.ReceivedAtMostOnce().Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueAboveMaximum_DoesNothing()
	{
		// Arrange
		int value = 11;
		int minimum = 0;
		int maximum = 10;

		_comparer.Compare(value, minimum).Returns(value.CompareTo(minimum));
		_comparer.Compare(value, maximum).Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert, value, minimum, maximum, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.ReceivedAtMostOnce().Compare(value, minimum);
		_comparer.ReceivedAtMostOnce().Compare(value, maximum);

		MSAssert.AreEqual(_assert, result);
	}
	#endregion
}
