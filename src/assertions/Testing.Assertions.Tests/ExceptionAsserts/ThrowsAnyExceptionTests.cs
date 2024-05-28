namespace Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Test methods don't need the 'async' suffix.")]
public sealed class ThrowsAnyExceptionTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region Tests
   [TestMethod]
   public void ThrowsAnyException_WithExceptionThrown_DoesNothing()
   {
      // Arrange
      static void Action() => throw new TestException();

      // Act
      IAssert result = AssertExtensions.ThrowsAnyException(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsAnyException_NoExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() { }

      // Act
      IAssert result = AssertExtensions.ThrowsAnyException(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsAnyException_WithOutException_WithExceptionThrown_DoesNothing()
   {
      // Arrange
      TestException expectedException = new TestException();
      void Action() => throw expectedException;

      // Act
      IAssert result = AssertExtensions.ThrowsAnyException(
         _assert.Object,
         Action,
         out Exception exception);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(expectedException, exception);
      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsAnyException_WithOutException_NoExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() { }

      // Act
      IAssert result = AssertExtensions.ThrowsAnyException(
         _assert.Object,
         Action,
         out Exception? exception);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.IsNull(exception);
      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public async Task ThrowsAnyException_ValueTaskActionWithExceptionThrownDoesNothing()
   {
      // Arrange
      TestException expectedException = new();
      ValueTask Action() => throw expectedException;

      // Act
      Exception resultException = await AssertExtensions.ThrowsAnyExceptionAsync(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(expectedException, resultException);
   }

   [TestMethod]
   public async Task ThrowsAnyException_ValueTaskActionWithNoExceptionThrown_CallsFail()
   {
      // Arrange
      static ValueTask Action() => default;

      // Act
      await AssertExtensions.ThrowsAnyExceptionAsync(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();
   }

   [TestMethod]
   public async Task ThrowsAnyException_TaskActionWithExceptionThrownDoesNothing()
   {
      // Arrange
      TestException expectedException = new();
      Task Action() => throw expectedException;

      // Act
      Exception resultException = await AssertExtensions.ThrowsAnyExceptionAsync(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(expectedException, resultException);
   }

   [TestMethod]
   public async Task ThrowsAnyException_TaskActionWithNoExceptionThrown_CallsFail()
   {
      // Arrange
      static Task Action() => Task.CompletedTask;

      // Act
      await AssertExtensions.ThrowsAnyExceptionAsync(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();
   }
   #endregion
}
