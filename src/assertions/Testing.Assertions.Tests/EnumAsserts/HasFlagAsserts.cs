namespace OwlDomain.Testing.Assertions.Tests.EnumAsserts;

[TestClass]
public sealed class HasFlagAsserts
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region HasFlag tests
	[TestMethod]
	public void HasFlag_NonNullable_ValueHasFlag_DoesNothing()
	{
		// Arrange
		TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum flag = TestFlagEnum.B;

		// Act
		IAssert result = AssertExtensions.HasFlag(_assert, value, flag);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void HasFlag_NonNullable_ValueWithoutFlag_CallsFail()
	{
		// Arrange
		TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum flag = TestFlagEnum.C;

		// Act
		IAssert result = AssertExtensions.HasFlag(_assert, value, flag);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void HasFlag_Nullable_ValueHasFlag_DoesNothing()
	{
		// Arrange
		TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum? flag = TestFlagEnum.B;

		// Act
		IAssert result = AssertExtensions.HasFlag(_assert, value, flag);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void HasFlag_Nullable_ValueWithoutFlag_CallsFail()
	{
		// Arrange
		TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum? flag = TestFlagEnum.C;

		// Act
		IAssert result = AssertExtensions.HasFlag(_assert, value, flag);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}
	#endregion

	#region DoesNotHaveFlag tests
	[TestMethod]
	public void DoesNotHaveFlag_NonNullable_ValueWithoutFlag_DoesNothing()
	{
		// Arrange
		TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum flag = TestFlagEnum.C;

		// Act
		IAssert result = AssertExtensions.DoesNotHaveFlag(_assert, value, flag);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void DoesNotHaveFlag_NonNullable_ValueHasFlag_CallsFail()
	{
		// Arrange
		TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum flag = TestFlagEnum.B;

		// Act
		IAssert result = AssertExtensions.DoesNotHaveFlag(_assert, value, flag);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void DoesNotHaveFlag_Nullable_ValueWithoutFlag_DoesNothing()
	{
		// Arrange
		TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum? flag = TestFlagEnum.C;

		// Act
		IAssert result = AssertExtensions.DoesNotHaveFlag(_assert, value, flag);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(_assert, result);
	}

	[TestMethod]
	public void DoesNotHaveFlag_Nullable_ValueHasFlag_CallsFail()
	{
		// Arrange
		TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
		TestFlagEnum? flag = TestFlagEnum.B;

		// Act
		IAssert result = AssertExtensions.DoesNotHaveFlag(_assert, value, flag);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreEqual(_assert, result);
	}
	#endregion
}
