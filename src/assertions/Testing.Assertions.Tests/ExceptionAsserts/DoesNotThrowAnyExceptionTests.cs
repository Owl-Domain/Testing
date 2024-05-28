namespace Testing.Assertions.Tests.ExceptionAsserts;

[TestClass]
public sealed class DoesNotThrowAnyExceptionTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region Tests
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

   [TestMethod]
   public void DoesNotThrowAnyException_WithActionResult_WithExceptionThrown_CallsFail()
   {
      // Arrange
      static int Action() => throw new TestException();

      // Act
      IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert.Object, Action, out _);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotThrowAnyException_WithActionResult_NoExceptionThrown_CorrectResultReturned()
   {
      // Arrange
      const int expectedResult = 1;
      static int Action() => expectedResult;

      // Act
      IAssert result = AssertExtensions.DoesNotThrowAnyException(_assert.Object, Action, out int actionResult);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
      MSAssert.AreEqual(expectedResult, actionResult);
   }
   #endregion
}
