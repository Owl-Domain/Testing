namespace OwlDomain.Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class ThrowsAnyExceptionTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region Tests
	[TestMethod]
	public void ThrowsAnyException_WithExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new TestException();

		// Act
		IAssert result = AssertExtensions.ThrowsAnyException(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsAnyException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsAnyException(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsAnyException_WithOutException_WithExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new TestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsAnyException(
			_assert,
			Action,
			out Exception exception);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsAnyException_WithOutException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsAnyException(
			_assert,
			Action,
			out Exception? exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task ThrowsAnyException_ValueTaskActionWithExceptionThrownDoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		Exception resultException = await AssertExtensions.ThrowsAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsAnyException_ValueTaskActionWithNoExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => default;

		// Act
		await AssertExtensions.ThrowsAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsAnyException_TaskActionWithExceptionThrownDoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		Exception resultException = await AssertExtensions.ThrowsAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsAnyException_TaskActionWithNoExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => Task.CompletedTask;

		// Act
		await AssertExtensions.ThrowsAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}
	#endregion
}
