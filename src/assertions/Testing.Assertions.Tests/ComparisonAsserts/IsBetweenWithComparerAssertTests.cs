namespace OwlDomain.Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public sealed class IsBetweenWithComparerAssertTests
{
	#region Fields
	private readonly Mock<IAssert> _assert = new Mock<IAssert>();
	private readonly Mock<IComparer<int>> _comparer = new Mock<IComparer<int>>();
	#endregion

	#region IsBetween tests
	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_AllNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
	{
		// Arrange
		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));

		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsBetween_AllNullable_WithValueBelowMinimum_CallsFail()
	{
		// Arrange
		int? value = -1;
		int? minimum = 0;
		int? maximum = 10;

		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));
		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsBetween_AllNullable_WithValueAboveMaximum_CallsFail()
	{
		// Arrange
		int? value = 11;
		int? minimum = 0;
		int? maximum = 10;

		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));
		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsBetween_NoneNullable_WithValueInsideRange_DoesNothing(int value, int minimum, int maximum)
	{
		// Arrange
		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));

		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.Once());
		_comparer.Verify(c => c.Compare(value, maximum), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsBetween_NoneNullable_WithValueBelowMinimum_CallsFail()
	{
		// Arrange
		int value = -1;
		int minimum = 0;
		int maximum = 10;

		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));
		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.Once());
		_comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsBetween_NoneNullable_WithValueAboveMaximum_CallsFail()
	{
		// Arrange
		int value = 11;
		int minimum = 0;
		int maximum = 10;

		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));
		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value, maximum), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
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
		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));

		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueBelowMinimum_DoesNothing()
	{
		// Arrange
		int? value = -1;
		int? minimum = 0;
		int? maximum = 10;

		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));
		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsNotBetween_AllNullable_WithValueAboveMaximum_DoesNothing()
	{
		// Arrange
		int? value = 11;
		int? minimum = 0;
		int? maximum = 10;

		_comparer
			.Setup(c => c.Compare(value.Value, minimum.Value))
			.Returns(value.Value.CompareTo(minimum.Value));
		_comparer
			.Setup(c => c.Compare(value.Value, maximum.Value))
			.Returns(value.Value.CompareTo(maximum.Value));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[DataRow(5, 0, 10, DisplayName = "In-between")]
	[DataRow(0, 0, 10, DisplayName = "Same as minimum")]
	[DataRow(10, 0, 10, DisplayName = "Same as maximum")]
	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueInsideRange_CallsFail(int value, int minimum, int maximum)
	{
		// Arrange
		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));

		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueBelowMinimum_DoesNothing()
	{
		// Arrange
		int value = -1;
		int minimum = 0;
		int maximum = 10;

		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));
		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}

	[TestMethod]
	public void IsNotBetween_NoneNullable_WithValueAboveMaximum_DoesNothing()
	{
		// Arrange
		int value = 11;
		int minimum = 0;
		int maximum = 10;

		_comparer
			.Setup(c => c.Compare(value, minimum))
			.Returns(value.CompareTo(minimum));
		_comparer
			.Setup(c => c.Compare(value, maximum))
			.Returns(value.CompareTo(maximum));

		// Act
		IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
		_comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreEqual(_assert.Object, result);
	}
	#endregion
}
