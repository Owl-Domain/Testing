namespace Testing.MSTest.Tests;

[TestClass]
public class InconclusiveAssertTests
{
   #region Fields
   private readonly InconclusiveAssert _sut = new();
   #endregion

   #region Tests
   [TestMethod]
   public void Fail_WithMessage_ThrowsAssertInconclusiveException()
   {
      // Arrange
      string message = "message";

      // Act
      void Act() => _sut.Fail(message);

      // Assert
      MSAssert.ThrowsException<AssertInconclusiveException>(Act);
   }

   [TestMethod]
   public void Fail_WithFormat_ThrowsAssertInconclusiveException()
   {
      // Arrange
      string format = "{0} format {1}";
      object?[] args = [1, 2];

      // Act
      void Act() => _sut.Fail(format, args);

      // Assert
      MSAssert.ThrowsException<AssertInconclusiveException>(Act);
   }
   #endregion
}
