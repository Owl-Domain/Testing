namespace OwlDomain.Testing.Assertions.Tests.BooleanAsserts;

[TestClass]
public sealed class FalseAssertTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region IsFalse tests
	[TestMethod]
	public void IsFalse_WithFalseValue_DoesNothing()
	{
		// Arrange
		bool? value = false;

		// Act
		IAssert result = AssertExtensions.IsFalse(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(data: true, DisplayName = "True")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsFalse_WithNotFalseValue_CallsFail(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsFalse(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}
	#endregion

	#region IsNotFalse tests
	[TestMethod]
	public void IsNotFalse_WithFalseValue_CallsFail()
	{
		// Arrange
		bool? value = false;

		// Act
		IAssert result = AssertExtensions.IsNotFalse(_assert, value);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[DataRow(data: true, DisplayName = "True")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsNotFalse_WithNotFalseValue_DoesNothing(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsNotFalse(_assert, value);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}
	#endregion
}
