namespace OwlDomain.Testing.Assertions.Tests.DefaultAsserts;

[TestClass]
public sealed class IsDefaultWithComparerAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	private readonly IEqualityComparer<int> _comparer = Substitute.For<IEqualityComparer<int>>();
	#endregion

	#region IsDefault tests
	[TestMethod]
	public void IsDefault_WithDefaultValue_DoesNothing()
	{
		// Arrange
		int value = default;

		_comparer.Equals(value, default).Returns(true);

		// Act
		IAssert result = AssertExtensions.IsDefault(_assert, value, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();
		_comparer.Received(1).Equals(value, default);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsDefault_WithNonDefaultValue_CallsFail()
	{
		// Arrange
		int value = 1;

		_comparer.Equals(value, default).Returns(false);

		// Act
		IAssert result = AssertExtensions.IsDefault(_assert, value, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();
		_comparer.Received(1).Equals(value, default);

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotDefault tests
	[TestMethod]
	public void IsNotDefault_WithNonDefaultValue_DoesNothing()
	{
		// Arrange
		int value = 1;

		_comparer.Equals(value, default).Returns(false);

		// Act
		IAssert result = AssertExtensions.IsNotDefault(_assert, value, _comparer);

		// Assert
		_assert.VerifyNoFailFormat();
		_comparer.Received(1).Equals(value, default);

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNotDefault_WithDefaultValue_CallsFail()
	{
		// Arrange
		int value = default;

		_comparer.Equals(value, default).Returns(true);

		// Act
		IAssert result = AssertExtensions.IsNotDefault(_assert, value, _comparer);

		// Assert
		_assert.VerifyFailFormatOnce();
		_comparer.Received(1).Equals(value, default);

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
