﻿namespace Testing.Assertions.Tests.EnumAsserts;

[TestClass]
public class HasFlagAsserts
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region HasFlag tests
   [TestMethod]
   public void HasFlag_NonNullable_ValueHasFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_NonNullable_ValueWithoutFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_ValueNullable_ValueHasFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_ValueNullable_ValueWithoutFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_FlagNullable_ValueHasFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_FlagNullable_ValueWithoutFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_BothNullable_ValueHasFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void HasFlag_BothNullable_ValueWithoutFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.HasFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region DoesNotHaveFlag tests
   [TestMethod]
   public void DoesNotHaveFlag_NonNullable_ValueWithoutFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_NonNullable_ValueHasFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_ValueNullable_ValueWithoutFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_ValueNullable_ValueHasFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_FlagNullable_ValueWithoutFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_FlagNullable_ValueHasFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_BothNullable_ValueWithoutFlag_DoesNothing()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.C;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void DoesNotHaveFlag_BothNullable_ValueHasFlag_CallsFail()
   {
      // Arrange
      TestFlagEnum? value = TestFlagEnum.A | TestFlagEnum.B;
      TestFlagEnum? flag = TestFlagEnum.B;

      // Act
      IAssert result = AssertExtensions.DoesNotHaveFlag(_assert.Object, value, flag);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion
}
