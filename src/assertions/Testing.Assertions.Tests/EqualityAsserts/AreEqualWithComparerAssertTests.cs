namespace OwlDomain.Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreEqualWithComparerAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	private readonly IEqualityComparer<int> _comparer = Substitute.For<IEqualityComparer<int>>();
	#endregion

	#region AreEqual tests
	[TestMethod]
	public void AreEqual_WithEqualValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 5;

		_comparer.Equals(value, expected).Returns(true);

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, _comparer);

		// Arrange
		_assert.VerifyNoFailFormat();
		_comparer.Received(1).Equals(value, expected);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreEqual_WithDifferentValues_CallsFail()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		_comparer.Equals(value, expected).Returns(false);

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected, _comparer);

		// Arrange
		_assert.VerifyFailFormatOnce();
		_comparer.Received(1).Equals(value, expected);

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region AreNotEqual tests
	[TestMethod]
	public void AreNotEqual_WithEqualValues_CallsFail()
	{
		// Arrange
		int value = 5;
		int expected = 5;

		_comparer.Equals(value, expected).Returns(true);

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, _comparer);

		// Arrange
		_assert.VerifyFailFormatOnce();
		_comparer.Received(1).Equals(value, expected);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotEqual_WithDifferentValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		_comparer.Equals(value, expected).Returns(false);

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected, _comparer);

		// Arrange
		_assert.VerifyNoFailFormat();
		_comparer.Received(1).Equals(value, expected);

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
