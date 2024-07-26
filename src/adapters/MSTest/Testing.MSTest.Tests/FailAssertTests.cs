namespace Testing.MSTest.Tests;

[TestClass]
public sealed class FailAssertTests
{
   #region Fields
   private readonly FailAssert _sut = new();
   #endregion

   #region Tests
   [TestMethod]
   public void Fail_WithMessage_ThrowsAssertFailedException()
   {
      // Arrange
      string message = "message";

      // Act
      void Act() => _sut.Fail(message);

      // Assert
      MSAssert.ThrowsException<AssertFailedException>(Act);
   }

   [TestMethod]
   public void Fail_WithFormat_ThrowsAssertFailedException()
   {
      // Arrange
      string format = "{0} format {1}";
      object?[] args = [1, 2];

      // Act
      void Act() => _sut.Fail(format, args);

      // Assert
      MSAssert.ThrowsException<AssertFailedException>(Act);
   }
   #endregion
}
