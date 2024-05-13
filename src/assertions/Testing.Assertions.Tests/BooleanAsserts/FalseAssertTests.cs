namespace Testing.Assertions.Tests.BooleanAsserts;

[TestClass]
public class FalseAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsFalse tests
   [TestMethod]
   public void IsFalse_WithFalseValue_DoesNothing()
   {
      // Arrange
      bool? value = false;

      // Act
      IAssert result = AssertExtensions.IsFalse(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(data: true, DisplayName = "True")]
   [DataRow(data: null, DisplayName = "Null")]
   [TestMethod]
   public void IsFalse_WithNotFalseValue_CallsFail(bool? value)
   {
      // Act
      IAssert result = AssertExtensions.IsFalse(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotFalse tests
   [TestMethod]
   public void IsNotFalse_WithFalseValue_CallsFail()
   {
      // Arrange
      bool? value = false;

      // Act
      IAssert result = AssertExtensions.IsNotFalse(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(data: true, DisplayName = "True")]
   [DataRow(data: null, DisplayName = "Null")]
   [TestMethod]
   public void IsNotFalse_WithNotFalseValue_DoesNothing(bool? value)
   {
      // Act
      IAssert result = AssertExtensions.IsNotFalse(_assert.Object, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
