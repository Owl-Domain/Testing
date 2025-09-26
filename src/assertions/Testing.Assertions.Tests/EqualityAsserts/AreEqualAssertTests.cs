namespace OwlDomain.Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreEqualAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region AreEqual tests
	[TestMethod]
	public void AreEqual_WithEqualValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 5;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected);

		// Arrange
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreEqual_WithDifferentValues_CallsFail()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		// Act
		IAssert result = AssertExtensions.AreEqual(_assert, value, expected);

		// Arrange
		_assert.VerifyFailFormatOnce();

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

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected);

		// Arrange
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void AreNotEqual_WithDifferentValues_DoesNothing()
	{
		// Arrange
		int value = 5;
		int expected = 6;

		// Act
		IAssert result = AssertExtensions.AreNotEqual(_assert, value, expected);

		// Arrange
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
