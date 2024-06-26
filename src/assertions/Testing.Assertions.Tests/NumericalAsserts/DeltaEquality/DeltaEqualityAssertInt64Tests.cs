﻿namespace Testing.Assertions.Tests.NumericalAsserts.DeltaEquality;

[TestClass]
public class DeltaEqualityAssertInt64Tests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region AreEqual tests
   [TestMethod]
   public void AreEqual_Nullable_WithinDelta_DoesNothing()
   {
      // Arrange
      long? value = 5;
      long? expected = 10;
      long? delta = 10;

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
      long? value = 5;
      long? expected = 10;
      long? delta = 1;

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
      long value = 5;
      long expected = 10;
      long delta = 10;

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
      long value = 5;
      long expected = 10;
      long delta = 1;

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
      long? value = 5;
      long? expected = 10;
      long? delta = 10;

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
      long? value = 5;
      long? expected = 10;
      long? delta = 1;

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
      long value = 5;
      long expected = 10;
      long delta = 10;

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
      long value = 5;
      long expected = 10;
      long delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
