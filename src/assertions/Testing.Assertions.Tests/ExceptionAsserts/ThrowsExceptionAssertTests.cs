namespace Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
public class ThrowsExceptionAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region ThrowsAnyException tests
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

   #region ThrowsExceptionOfType tests
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
   #endregion

   #region ThrowsExactException tests
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

   #region DoesNotThrowAnyException tests
   [TestMethod]
   public void DoesNotThrowAnyException_WithExceptionThrown_CallsFail()
   {
      // Arrange
      static void Action() => throw new Exception();

      // Act
      IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotThrowAnyException_NoExceptionThrown_DoesNothing()
   {
      // Arrange
      static void Action() { }

      // Act
      IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert.Object, Action);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
