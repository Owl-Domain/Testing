namespace Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreEqualAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region AreEqual tests
   [TestMethod]
   public void AreEqual_WithEqualValues_DoesNothing()
   {
      // Arrange
      int value = 5;
      int expected = 5;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected);

      // Arrange
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_WithDifferentValues_CallsFail()
   {
      // Arrange
      int value = 5;
      int expected = 6;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected);

      // Arrange
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region AreNotEqual tests
   [TestMethod]
   public void AreNotEqual_WithEqualValues_CallsFail()
   {
      // Arrange
      int value = 5;
      int expected = 5;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected);

      // Arrange
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_WithDifferentValues_DoesNothing()
   {
      // Arrange
      int value = 5;
      int expected = 6;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected);

      // Arrange
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
