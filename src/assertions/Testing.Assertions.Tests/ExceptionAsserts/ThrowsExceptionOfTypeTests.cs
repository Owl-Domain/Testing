namespace OwlDomain.Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class ThrowsExceptionOfTypeTests
{
	#region Fields
	private readonly Mock<IAssert> _assert = new Mock<IAssert>();
	#endregion

	#region Tests
	[TestMethod]
	public void ThrowsExceptionOfType_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new TestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		static void Action() => throw new DerivedTestException();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType<Exception>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new TestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert.Object, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new DerivedTestException();
		void Action() => throw expectedException;

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert.Object, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, exception);
		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_WithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() => throw new Exception();

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert.Object, Action, out TestException exception);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public void ThrowsExceptionOfType_WithOutException_NoExceptionThrown_CallsFail()
	{
		// Arrange
		static void Action() { }

		// Act
		IAssert result = AssertExtensions.ThrowsExceptionOfType(_assert.Object, Action, out Exception exception);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();

		MSAssert.IsNull(exception);
		MSAssert.AreSame(_assert.Object, result);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		DerivedTestException expectedException = new();
		ValueTask Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_ValueTaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static ValueTask Action() => default;

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<Exception>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithExactExceptionThrown_DoesNothing()
	{
		// Arrange
		TestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithDerivedExceptionThrown_DoesNothing()
	{
		// Arrange
		DerivedTestException expectedException = new();
		Task Action() => throw expectedException;

		// Act
		TestException resultException = await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Never());
		_assert.VerifyNoOtherCalls();

		MSAssert.AreSame(expectedException, resultException);
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionWithDifferentExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => throw new Exception();

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<TestException>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();
	}

	[TestMethod]
	public async Task ThrowsExceptionOfType_TaskActionNoExceptionThrown_CallsFail()
	{
		// Arrange
		static Task Action() => Task.CompletedTask;

		// Act
		await AssertExtensions.ThrowsExceptionOfTypeAsync<Exception>(_assert.Object, Action);

		// Assert
		_assert.VerifyFailFormat(Times.Once());
		_assert.VerifyNoOtherCalls();
	}
	#endregion
}
