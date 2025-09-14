namespace Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreEqualWithComparerAssertTests
{
	#region Fields
	private readonly Mock<IAssert> _assert = new Mock<IAssert>();
	private readonly Mock<IEqualityComparer<int>> _comparer = new Mock<IEqualityComparer<int>>();
	#endregion

	#region AreEqual tests
	[TestMethod]
	public void AreEqual_WithEqualValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 5;

		_comparer
		   .Setup(c => c.Equals(value, expected))
		   .Returns(true);

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, _comparer.Object);

		// Arrange
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Equals(value, expected), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void AreEqual_WithDifferentValues_CallsFail()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		_comparer
		   .Setup(c => c.Equals(value, expected))
		   .Returns(false);

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, _comparer.Object);

		// Arrange
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Equals(value, expected), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}
	#endregion

	#region AreNotEqual tests
	[TestMethod]
	public void AreNotEqual_WithEqualValues_CallsFail()
	{
		// Arrange
		int value = 5;
		int expected = 5;

		_comparer
		   .Setup(c => c.Equals(value, expected))
		   .Returns(true);

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, _comparer.Object);

		// Arrange
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Equals(value, expected), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void AreNotEqual_WithDifferentValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		_comparer
		   .Setup(c => c.Equals(value, expected))
		   .Returns(false);

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, _comparer.Object);

		// Arrange
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		_comparer.Verify(c => c.Equals(value, expected), Times.Once());
		_comparer.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}
	#endregion
}
