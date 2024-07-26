namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public sealed class LessThanAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsLessThan tests
   [TestMethod]
   public void IsLessThan_Nullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThan_Nullable_WithNotLesserValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThan_NoneNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThan_NoneNullable_WithNotLesserValue_CallsFail(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsLessThanOrEqualTo tests
   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThanOrEqualTo_Nullable_WithLessOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_Nullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThanOrEqualTo_NoneNullable_WithLessOrEqualToValue_DoesNothing(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_NoneNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotLessThan tests
   [TestMethod]
   public void IsNotLessThan_Nullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThan_Nullable_WithNotLesserValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThan_NoneNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThan_NoneNullable_WithNotLesserValue_DoesNothing(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotLessThanOrEqualTo tests
   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThanOrEqualTo_Nullable_WithLessOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_Nullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThanOrEqualTo_NoneNullable_WithLessOrEqualToValue_CallsFail(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_NoneNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
