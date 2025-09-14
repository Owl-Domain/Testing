namespace Testing.Assertions.Tests.BooleanAsserts;

[TestClass]
public sealed class TrueAssertTests
{
	#region Fields
	private readonly Mock<IAssert> _assert = new Mock<IAssert>();
	#endregion

	#region IsTrue tests
	[TestMethod]
	public void IsTrue_WithTrueValue_DoesNothing()
	{
		// Arrange
		bool? value = true;

		// Act
		IAssert result = AssertExtensions.IsTrue(_assert.Object, value);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[DataRow(data: false, DisplayName = "False")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsTrue_WitNotTrueValue_CallsFail(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsTrue(_assert.Object, value);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}
	#endregion

	#region IsNotTrue tests
	[TestMethod]
	public void IsNotTrue_WithTrueValue_CallsFail()
	{
		// Arrange
		bool? value = true;

		// Act
		IAssert result = AssertExtensions.IsNotTrue(_assert.Object, value);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[DataRow(data: false, DisplayName = "False")]
	[DataRow(data: null, DisplayName = "Null")]
	[TestMethod]
	public void IsNotTrue_WithNotTrueValue_DoesNothing(bool? value)
	{
		// Act
		IAssert result = AssertExtensions.IsNotTrue(_assert.Object, value);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}
	#endregion
}
