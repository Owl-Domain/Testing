namespace OwlDomain.Testing.Assertions.Tests.DefaultAsserts;

[TestClass]
public sealed class IsDefaultAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region IsDefault tessts
	[TestMethod]
	public void IsDefault_WithDefaultValue_DoesNothing()
	{
		// Arrange
		int value = default;

		// Act
		IAssert result = AssertExtensions.IsDefault(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsDefault_WithNonDefaultValue_CallsFail()
	{
		// Arrange
		int value = 1;

		// Act
		IAssert result = AssertExtensions.IsDefault(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotDefault tessts
	[TestMethod]
	public void IsNotDefault_WithNonDefaultValue_DoesNothing()
	{
		// Arrange
		int value = 1;

		// Act
		IAssert result = AssertExtensions.IsNotDefault(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void IsNotDefault_WithDefaultValue_CallsFail()
	{
		// Arrange
		int value = default;

		// Act
		IAssert result = AssertExtensions.IsNotDefault(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
