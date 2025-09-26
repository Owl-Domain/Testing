namespace OwlDomain.Testing.Assertions.Tests.BooleanAsserts;

[TestClass]
public sealed class TrueAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region IsTrue tests
	[TestMethod]
	public void IsTrue_WithTrueValue_DoesNothing()
	{
		// Arrange
		bool? value = true;

		// Act
		IAssert result = AssertExtensions.IsTrue(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(data: false, DisplayName = "False")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsTrue_WitNotTrueValue_CallsFail(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsTrue(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotTrue tests
	[TestMethod]
	public void IsNotTrue_WithTrueValue_CallsFail()
	{
		// Arrange
		bool? value = true;

		// Act
		IAssert result = AssertExtensions.IsNotTrue(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(data: false, DisplayName = "False")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsNotTrue_WithNotTrueValue_DoesNothing(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsNotTrue(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
