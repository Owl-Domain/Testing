namespace OwlDomain.Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class ThrowsExactExceptionTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region Tests
	[TestMethod]
	public void ThrowsExactException_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new TestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithDerivedExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new DerivedTestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExactException<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithOutException_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new TestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsExactException(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithOutException_WithDerivedExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new DerivedTestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExactException(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithOutException_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExactException(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExactException_WithOutException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExactException(_assert, Action, out Exception exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task ThrowsExactException_ValueTaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExactException_ValueTaskActionWithDerivedExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => throw new DerivedTestException();

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExactException_ValueTaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExactException_ValueTaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => default;

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExactException_TaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExactException_TaskActionWithDerivedExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => throw new DerivedTestException();

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExactException_TaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExactException_TaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => Task.CompletedTask;

		// Act
		await AssertExtensions.ThrowsExactExceptionAsync<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}
	#endregion
}
