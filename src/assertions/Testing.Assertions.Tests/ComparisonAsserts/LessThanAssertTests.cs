namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public class LessThanAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsLessThan tests
   [TestMethod]
   public void IsLessThan_BothNullable_WithLesserValue_DoesNothing()
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
   public void IsLessThan_BothNullable_WithNotLesserValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThan_ValueNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
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
   public void IsLessThan_ValueNullable_WithNotLesserValue_CallsFail([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThan_ThresholdNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
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
   public void IsLessThan_ThresholdNullable_WithNotLesserValue_CallsFail(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThan_Comparable_WithLesserValue_DoesNothing()
   {
      // Arrange
      IComparable<int> value = 4;
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
   public void IsLessThan_Comparable_WithNotLesserValue_CallsFail(IComparable<int> value, int threshold)
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
   public void IsLessThanOrEqualTo_BothNullable_WithLessOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_BothNullable_WithGreaterValue_CallsFail()
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
   public void IsLessThanOrEqualTo_ValueNullable_WithLessOrEqualToValue_DoesNothing([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_ValueNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
      int threshold = 5;

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
   public void IsLessThanOrEqualTo_ThresholdNullable_WithLessOrEqualToValue_DoesNothing(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_ThresholdNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
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
   public void IsLessThanOrEqualTo_Comparable_WithLessOrEqualToValue_DoesNothing(IComparable<int> value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_Comparable_WithGreaterValue_CallsFail()
   {
      // Arrange
      IComparable<int> value = 6;
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
   public void IsNotLessThan_BothNullable_WithLesserValue_CallsFail()
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
   public void IsNotLessThan_BothNullable_WithNotLesserValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThan_ValueNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int? value = 4;
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
   public void IsNotLessThan_ValueNullable_WithNotLesserValue_DoesNothing([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThan_ThresholdNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
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
   public void IsNotLessThan_ThresholdNullable_WithNotLesserValue_DoesNothing(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThan_Comparable_WithLesserValue_CallsFail()
   {
      // Arrange
      IComparable<int> value = 4;
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
   public void IsNotLessThan_Comparable_WithNotLesserValue_DoesNothing(IComparable<int> value, int threshold)
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
   public void IsNotLessThanOrEqualTo_BothNullable_WithLessOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_BothNullable_WithGreaterValue_DoesNothing()
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
   public void IsNotLessThanOrEqualTo_ValueNullable_WithLessOrEqualToValue_CallsFail([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_ValueNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int threshold = 5;

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
   public void IsNotLessThanOrEqualTo_ThresholdNullable_WithLessOrEqualToValue_CallsFail(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_ThresholdNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
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
   public void IsNotLessThanOrEqualTo_Comparable_WithLessOrEqualToValue_CallsFail(IComparable<int> value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_Comparable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      IComparable<int> value = 6;
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
