namespace Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
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
   #endregion
}
