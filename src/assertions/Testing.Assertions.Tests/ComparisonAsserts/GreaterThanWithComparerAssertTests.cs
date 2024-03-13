namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public class GreaterThanWithComparerAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   private readonly Mock<IComparer<int>> _comparer = new Mock<IComparer<int>>();
   #endregion

   #region IsGreaterThan tests
   [TestMethod]
   public void IsGreaterThan_BothNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_BothNullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_ValueNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_ValueNullable_WithNotGreaterValue_CallsFail([DisallowNull] int? value, int threshold, int comparisonResult)
   {
      //Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_ThresholdNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_ThresholdNullable_WithNotGreaterValue_CallsFail(int value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThan_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThan_WithNotGreaterValue_CallsFail(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsGreaterThanOrEqualTo tests
   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_BothNullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_BothNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_ValueNullable_WithGreaterOrEqualToValue_DoesNothing([DisallowNull] int? value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_ValueNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int? value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_ThresholdNullable_WithGreaterOrEqualToValue_DoesNothing(int value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_ThresholdNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsGreaterThanOrEqualTo_WithGreaterOrEqualToValue_DoesNothing(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsGreaterThanOrEqualTo_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

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

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_BothNullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_ValueNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_ValueNullable_WithNotGreaterValue_DoesNothing([DisallowNull] int? value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_ThresholdNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_ThresholdNullable_WithNotGreaterValue_DoesNothing(int value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThan_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Less than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThan_WithNotGreaterValue_DoesNothing(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotGreaterThanOrEqualTo tests
   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_BothNullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_BothNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ValueNullable_WithGreaterOrEqualToValue_CallsFail([DisallowNull] int? value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ValueNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ThresholdNullable_WithGreaterOrEqualToValue_CallsFail(int value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_ThresholdNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_WithGreaterOrEqualToValue_CallsFail(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotGreaterThanOrEqualTo_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotGreaterThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
