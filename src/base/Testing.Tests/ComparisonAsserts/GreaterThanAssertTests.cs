namespace Testing.Tests.ComparisonAsserts;

[TestClass]
public class GreaterThanAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsGreaterThan tests
   [TestMethod]
   public void IsGreaterThan_BothNullable_WithGreaterValue_DoesNothing()
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
   public void IsGreaterThan_BothNullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_ValueNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
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
   public void IsGreaterThan_ValueNullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_ThresholdNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
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
   public void IsGreaterThan_ThresholdNullable_WithNotGreaterValue_CallsFail(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_Comparable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      IComparable<int> value = 6;
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
   public void IsGreaterThan_Comparable_WithNotGreaterValue_CallsFail(IComparable<int> value, int threshold)
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
   public void IsGreaterThanOrEqualTo_BothNullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_BothNullable_WithLowerValue_CallsFail()
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
   public void IsGreaterThanOrEqualTo_ValueNullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_ValueNullable_WithLowerValue_CallsFail()
   {
      // Arrange
      int? value = 4;
      int threshold = 5;

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
   public void IsGreaterThanOrEqualTo_ThresholdNullable_WithGreaterOrEqualToValue_DoesNothing(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_ThresholdNullable_WithLowerValue_CallsFail()
   {
      // Arrange
      int value = 4;
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
   public void IsGreaterThanOrEqualTo_Comparable_WithGreaterOrEqualToValue_DoesNothing(IComparable<int> value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_Comparable_WithLowerValue_CallsFail()
   {
      // Arrange
      IComparable<int> value = 4;
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
   public void IsNotGreaterThan_BothNullable_WithGreaterValue_CallsFail()
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
   public void IsNotGreaterThan_BothNullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_ValueNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
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
   public void IsNotGreaterThan_ValueNullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_ThresholdNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
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
   public void IsNotGreaterThan_ThresholdNullable_WithNotGreaterValue_DoesNothing(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_Comparable_WithGreaterValue_CallsFail()
   {
      // Arrange
      IComparable<int> value = 6;
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
   public void IsNotGreaterThan_Comparable_WithNotGreaterValue_DoesNothing(IComparable<int> value, int threshold)
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
   public void IsNotGreaterThanOrEqualTo_BothNullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_BothNullable_WithLowerValue_DoesNothing()
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
   public void IsNotGreaterThanOrEqualTo_ValueNullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ValueNullable_WithLowerValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int threshold = 5;

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
   public void IsNotGreaterThanOrEqualTo_ThresholdNullable_WithGreaterOrEqualToValue_CallsFail(int value, [DisallowNull] int? threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ThresholdNullable_WithLowerValue_DoesNothing()
   {
      // Arrange
      int value = 4;
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
   public void IsNotGreaterThanOrEqualTo_Comparable_WithGreaterOrEqualToValue_CallsFail(IComparable<int> value, int threshold)
   {
      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_Comparable_WithLowerValue_DoesNothing()
   {
      // Arrange
      IComparable<int> value = 4;
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
