namespace OwlDomain.Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public sealed class GreaterThanWithComparerAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	private readonly IComparer<int> _comparer = Substitute.For<IComparer<int>>();
	#endregion

	#region IsGreaterThan tests
	[TestMethod]
	public void IsGreaterThan_Nullable_WithGreaterValue_DoesNothing()
	{
		// Arrange
		int? value = 6;
		int? threshold = 5;

		_comparer.Compare(value.Value, threshold.Value).Returns(1);

		// Act
		IAssert result = AssertExtensions.IsGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(4, 5, -1, DisplayName = "Less than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsGreaterThan_Nullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value.Value, threshold.Value).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsGreaterThan_NoneNullable_WithGreaterValue_DoesNothing()
	{
		// Arrange
		int value = 6;
		int threshold = 5;

		_comparer.Compare(value, threshold).Returns(1);

		// Act
		IAssert result = AssertExtensions.IsGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(4, 5, -1, DisplayName = "Less than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsGreaterThan_NoneNullable_WithNotGreaterValue_CallsFail(int value, int threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value, threshold).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreEqual(_assert, result);
	}
	#endregion

	#region IsGreaterThanOrEqualTo tests
	[DataRow(6, 5, 1, DisplayName = "Greater than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsGreaterThanOrEqualTo_Nullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value.Value, threshold.Value).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsGreaterThanOrEqualTo_Nullable_WithLesserValue_CallsFail()
	{
		// Arrange
		int? value = 4;
		int? threshold = 5;

		_comparer.Compare(value.Value, threshold.Value).Returns(-1);

		// Act
		IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(6, 5, 1, DisplayName = "Greater than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsGreaterThanOrEqualTo_NoneNullable_WithGreaterOrEqualToValue_DoesNothing(int value, int threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value, threshold).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsGreaterThanOrEqualTo_NoneNullable_WithLesserValue_CallsFail()
	{
		// Arrange
		int value = 4;
		int threshold = 5;

		_comparer.Compare(value, threshold).Returns(-1);

		// Act
		IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotGreaterThan tests
	[TestMethod]
	public void IsNotGreaterThan_Nullable_WithGreaterValue_CallsFail()
	{
		// Arrange
		int? value = 6;
		int? threshold = 5;

		_comparer.Compare(value.Value, threshold.Value).Returns(1);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(4, 5, -1, DisplayName = "Less than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsNotGreaterThan_Nullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value.Value, threshold.Value).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void IsNotGreaterThan_NoneNullable_WithGreaterValue_CallsFail()
	{
		// Arrange
		int value = 6;
		int threshold = 5;

		_comparer.Compare(value, threshold).Returns(1);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreEqual(_assert, result);
	}

	[DataRow(4, 5, -1, DisplayName = "Less than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsNotGreaterThan_NoneNullable_WithNotGreaterValue_DoesNothing(int value, int threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value, threshold).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThan(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreEqual(_assert, result);
	}
	#endregion

	#region IsNotGreaterThanOrEqualTo tests
	[DataRow(6, 5, 1, DisplayName = "Greater than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsNotGreaterThanOrEqualTo_Nullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value.Value, threshold.Value).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNotGreaterThanOrEqualTo_Nullable_WithLesserValue_DoesNothing()
	{
		// Arrange
		int? value = 4;
		int? threshold = 5;

		_comparer.Compare(value.Value, threshold.Value).Returns(-1);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value.Value, threshold.Value);

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(6, 5, 1, DisplayName = "Greater than")]
	[DataRow(5, 5, 0, DisplayName = "Equal to")]
	[TestMethod]
	public void IsNotGreaterThanOrEqualTo_NoneNullable_WithGreaterOrEqualToValue_CallsFail(int value, int threshold, int comparisonResult)
	{
		// Arrange
		_comparer.Compare(value, threshold).Returns(comparisonResult);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNotGreaterThanOrEqualTo_NoneNullable_WithLesserValue_DoesNothing()
	{
		// Arrange
		int value = 4;
		int threshold = 5;

		_comparer.Compare(value, threshold).Returns(-1);

		// Act
		IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert, value, threshold, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();

		_comparer.Received(1).Compare(value, threshold);

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
