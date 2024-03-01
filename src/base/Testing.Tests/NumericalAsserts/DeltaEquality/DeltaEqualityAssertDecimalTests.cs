﻿namespace Testing.Tests.NumericalAsserts.DeltaEquality;

[TestClass]
public class DeltaEqualityAssertDecimalTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region AreEqual tests
   [TestMethod]
   public void AreEqual_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ExpectedNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ExpectedNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_DeltaNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_DeltaNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueAndExpectedNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueAndExpectedNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueAndDeltaNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ValueAndDeltaNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ExpectedAndDeltaNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_ExpectedAndDeltaNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_AllNullable_WithinDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreEqual_AllNullable_OutsideDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal? delta = 1;

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
   public void AreNotEqual_WithinDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ExpectedNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ExpectedNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_DeltaNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_DeltaNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueAndExpectedNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueAndExpectedNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueAndDeltaNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ValueAndDeltaNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ExpectedAndDeltaNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_ExpectedAndDeltaNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal value = 5;
      decimal? expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_AllNullable_WithinDelta_CallsFail()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal? delta = 10;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotEqual_AllNullable_OutsideDelta_DoesNothing()
   {
      // Arrange
      decimal? value = 5;
      decimal? expected = 10;
      decimal? delta = 1;

      // Act
      IAssert result = AssertExtensions.AreNotEqual(_assert.Object, value, expected, delta);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
