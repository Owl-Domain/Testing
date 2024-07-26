namespace Testing.Assertions.Tests.DefaultAsserts;

[TestClass]
public sealed class IsDefaultAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new();
   #endregion

   #region IsDefault tessts
   [TestMethod]
   public void IsDefault_WithDefaultValue_DoesNothing()
   {
      // Arrange
      int value = default;

      // Act
      IAssert result = AssertExtensions.IsDefault(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsDefault_WithNonDefaultValue_CallsFail()
   {
      // Arrange
      int value = 1;

      // Act
      IAssert result = AssertExtensions.IsDefault(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotDefault tessts
   [TestMethod]
   public void IsNotDefault_WithNonDefaultValue_DoesNothing()
   {
      // Arrange
      int value = 1;

      // Act
      IAssert result = AssertExtensions.IsNotDefault(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotDefault_WithDefaultValue_CallsFail()
   {
      // Arrange
      int value = default;

      // Act
      IAssert result = AssertExtensions.IsNotDefault(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
