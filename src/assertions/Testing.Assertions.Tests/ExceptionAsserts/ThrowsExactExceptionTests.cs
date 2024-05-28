namespace Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
public sealed class ThrowsExactExceptionTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region Tests
   [TestMethod]
   public void ThrowsExactException_WithExactExceptionThrown_DoesNothing()
   {
      // Arrange
      static void Action() => throw new TestException();

      // Act
      IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithDerivedExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() => throw new DerivedTestException();

      // Act
      IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithDifferentExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() => throw new Exception();

      // Act
      IAssert result = AssertExtensions.ThrowsExactException<TestException>(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_NoExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() { }

      // Act
      IAssert result = AssertExtensions.ThrowsExactException<Exception>(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithOutException_WithExactExceptionThrown_DoesNothing()
   {
      // Arrange
      TestException expectedException = new TestException();
      void Action() => throw expectedException;

      // Act
      IAssert result = AssertExtensions.ThrowsExactException(_assert.Object, Action, out TestException exception);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(expectedException, exception);
      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithOutException_WithDerivedExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() => throw new DerivedTestException();

      // Act
      IAssert result = AssertExtensions.ThrowsExactException(_assert.Object, Action, out TestException exception);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.IsNull(exception);
      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithOutException_WithDifferentExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() => throw new Exception();

      // Act
      IAssert result = AssertExtensions.ThrowsExactException(_assert.Object, Action, out TestException exception);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.IsNull(exception);
      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void ThrowsExactException_WithOutException_NoExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() { }

      // Act
      IAssert result = AssertExtensions.ThrowsExactException(_assert.Object, Action, out Exception exception);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.IsNull(exception);
      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
