namespace Testing.Assertions.Tests;

[TestClass]
public sealed class NullAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsNull tests
   [TestMethod]
   public void IsNull_WithNullValue_DoesNothing()
   {
      // Arrange
      object? value = null;

      // Act
      IAssert result = AssertExtensions.IsNull(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNull_WithNonNullValue_CallsFail()
   {
      // Arrange
      object? value = new();

      // Act
      IAssert result = AssertExtensions.IsNull(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotNull tests
   [TestMethod]
   public void IsNotNull_WithNullValue_CallsFail()
   {
      // Arrange
      object? value = null;

      // Act
      IAssert result = AssertExtensions.IsNotNull(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotNull_WithNonNullValue_DoesNothing()
   {
      // Arrange
      object? value = new();

      // Act
      IAssert result = AssertExtensions.IsNotNull(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
