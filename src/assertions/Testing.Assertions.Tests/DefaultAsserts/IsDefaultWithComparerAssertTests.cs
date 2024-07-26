namespace Testing.Assertions.Tests.DefaultAsserts;

[TestClass]
public sealed class IsDefaultWithComparerAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new();
   private readonly Mock<IEqualityComparer<int>> _comparer = new();
   #endregion

   #region IsDefault tests
   [TestMethod]
   public void IsDefault_WithDefaultValue_DoesNothing()
   {
      // Arrange
      int value = default;

      _comparer
         .Setup(c => c.Equals(value, default))
         .Returns(true);

      // Act
      IAssert result = AssertExtensions.IsDefault(_assert.Object, value, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Equals(value, default), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsDefault_WithNonDefaultValue_CallsFail()
   {
      // Arrange
      int value = 1;

      _comparer
         .Setup(c => c.Equals(value, default))
         .Returns(false);

      // Act
      IAssert result = AssertExtensions.IsDefault(_assert.Object, value, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Equals(value, default), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotDefault tests
   [TestMethod]
   public void IsNotDefault_WithNonDefaultValue_DoesNothing()
   {
      // Arrange
      int value = 1;

      _comparer
         .Setup(c => c.Equals(value, default))
         .Returns(false);

      // Act
      IAssert result = AssertExtensions.IsNotDefault(_assert.Object, value, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Equals(value, default), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotDefault_WithDefaultValue_CallsFail()
   {
      // Arrange
      int value = default;

      _comparer
         .Setup(c => c.Equals(value, default))
         .Returns(true);

      // Act
      IAssert result = AssertExtensions.IsNotDefault(_assert.Object, value, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Equals(value, default), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
