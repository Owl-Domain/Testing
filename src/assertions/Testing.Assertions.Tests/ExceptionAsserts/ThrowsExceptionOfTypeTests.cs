namespace OwlDomain.Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class ThrowsExceptionOfTypeTests
{
	#region Fields
	private readonly IAssert _assert = Substitute.For<IAssert>();
	#endregion

	#region Tests
	[TestMethod]
	public void ThrowsExceptionOfType_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new TestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new DerivedTestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new TestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new DerivedTestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert, Action, out Exception exception);

		// Assert
		_assert.VerifyFailFormatOnce();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert, result);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		DerivedTestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => default;

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		DerivedTestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyNoFailFormat();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => Task.CompletedTask;

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<Exception>(_assert, Action);

		// Assert
		_assert.VerifyFailFormatOnce();
	}
	#endregion
}
