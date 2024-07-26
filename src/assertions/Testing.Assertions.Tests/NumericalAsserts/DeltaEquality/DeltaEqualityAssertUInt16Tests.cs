namespace Testing.Assertions.Tests.NumericalAsserts.DeltaEquality;

[TestClass]
public sealed class DeltaEqualityAssertUInt16Tests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region AreEqual tests
   [TestMethod]
   public void AreEqual_Nullable_WithinDelta_DoesNothing()
   {
      // Arrange
      ushort? value = 5;
      ushort? expected = 10;
      ushort? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_Nullable_OutsideDelta_CallsFail()
   {
      // Arrange
      ushort? value = 5;
      ushort? expected = 10;
      ushort? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_NoneNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      ushort value = 5;
      ushort expected = 10;
      ushort delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_NoneNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      ushort value = 5;
      ushort expected = 10;
      ushort delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region AreNotEqual tests
   [TestMethod]
   public void AreNotEqual_Nullable_WithinDelta_CallsFail()
   {
      // Arrange
      ushort? value = 5;
      ushort? expected = 10;
      ushort? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_Nullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      ushort? value = 5;
      ushort? expected = 10;
      ushort? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_NoneNullable_WithinDelta_CallsFail()
   {
      // Arrange
      ushort value = 5;
      ushort expected = 10;
      ushort delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_NoneNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      ushort value = 5;
      ushort expected = 10;
      ushort delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
