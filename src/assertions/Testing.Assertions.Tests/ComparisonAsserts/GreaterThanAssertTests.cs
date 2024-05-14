namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public class GreaterThanAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsGreaterThan tests
   [TestMethod]
   public void IsGreaterThan_Nullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_Nullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_NoneNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_NoneNullable_WithNotGreaterValue_CallsFail(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsGreaterThanOrEqualTo tests
   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_Nullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_Nullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_NoneNullable_WithGreaterOrEqualToValue_DoesNothing(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_NoneNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region IsNotGreaterThan tests
   [TestMethod]
   public void IsNotGreaterThan_Nullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_Nullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_NoneNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, DisplayName = "Less than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_NoneNullable_WithNotGreaterValue_DoesNothing(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotGreaterThanOrEqualTo tests
   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_Nullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_Nullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, DisplayName = "Greater than")]
   [DataRow(5, 5, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_NoneNullable_WithGreaterOrEqualToValue_CallsFail(int value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_NoneNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
