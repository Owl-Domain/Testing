namespace OwlDomain.Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class DoesNotThrowAnyExceptionTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region Tests
	[TestMethod]
	public void DoesNotThrowAnyException_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void DoesNotThrowAnyException_NoExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void DoesNotThrowAnyException_WithActionResult_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static int Action() => throw new TestException();

		// Act
		IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert, Action, out _);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void DoesNotThrowAnyException_WithActionResult_NoExceptionThrown_CorrectResultReturned()
	{
		// Arrange
		const int expectedResult = 1;
		static int Action() => expectedResult;

		// Act
		IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert, Action, out int actionResult);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
		MSAssert.AreEqual(expectedResult, actionResult);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyExceptionAsync_WithValueTaskAction_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => throw new Exception();

		// Act
		IAssert result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyExceptionAsync_WithValueTaskAction_NoExceptionThrown_DoesNothing()
	{
		// Arrange
		static ValueTask Action() => default;

		// Act
		IAssert result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyExceptionAsync_WithTaskAction_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => throw new Exception();

		// Act
		IAssert result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyExceptionAsync_WithTaskAction_NoExceptionThrown_DoesNothing()
	{
		// Arrange
		static Task Action() => Task.CompletedTask;

		// Act
		IAssert result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyException_WithValueTaskActionResult_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask<int> Action() => throw new TestException();

		// Act
		int result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task DoesNotThrowAnyException_WithValueTaskActionResult_NoExceptionThrown_CorrectResultReturned()
	{
		// Arrange
		const int expectedResult = 1;
		static ValueTask<int> Action() => new(expectedResult);

		// Act
		int result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(expectedResult, result);
	}

	[TestMethod]
	public async Task DoesNotThrowAnyException_WithTaskActionResult_WithExceptionThrown_CallsFail()
	{
		// Arrange
		static Task<int> Action() => throw new TestException();

		// Act
		int result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task DoesNotThrowAnyException_WithTaskActionResult_NoExceptionThrown_CorrectResultReturned()
	{
		// Arrange
		const int expectedResult = 1;
		static Task<int> Action() => Task.FromResult(expectedResult);

		// Act
		int result = await AssertExtensions.DoesNotThrowAnyExceptionAsync(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreEqual(expectedResult, result);
	}
	#endregion
}
