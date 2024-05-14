namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public class LesserThanWithComparerAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   private readonly Mock<IComparer<int>> _comparer = new Mock<IComparer<int>>();
   #endregion

   #region IsLessThan tests
   [TestMethod]
   public void IsLessThan_Nullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int? value = 4;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThan_Nullable_WithNotLessValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThan_NoneNullable_WithLesserValue_DoesNothing()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThan_NoneNullable_WithNotLessValue_CallsFail(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsLessThanOrEqualTo tests
   [DataRow(4, 5, -1, DisplayName = "Lesser than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThanOrEqualTo_Nullable_WithLesserOrEqualToValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_Nullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Lesser than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsLessThanOrEqualTo_NoneNullable_WithLesserOrEqualToValue_DoesNothing(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsLessThanOrEqualTo_NoneNullable_WithGreaterValue_CallsFail()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

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

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThan_Nullable_WithNotLessValue_DoesNothing([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThan_NoneNullable_WithLesserValue_CallsFail()
   {
      // Arrange
      int value = 4;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(-1);

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(6, 5, 1, DisplayName = "Greater than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThan_NoneNullable_WithNotLessValue_DoesNothing(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotLessThan(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotLessThanOrEqualTo tests
   [DataRow(4, 5, -1, DisplayName = "Lesser than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThanOrEqualTo_Nullable_WithLesserOrEqualToValue_CallsFail([DisallowNull] int? value, [DisallowNull] int? threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_Nullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int? value = 6;
      int? threshold = 5;

      _comparer
         .Setup(c => c.Compare(value.Value, threshold.Value))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, threshold.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [DataRow(4, 5, -1, DisplayName = "Lesser than")]
   [DataRow(5, 5, 0, DisplayName = "Equal to")]
   [TestMethod]
   public void IsNotLessThanOrEqualTo_NoneNullable_WithLesserOrEqualToValue_CallsFail(int value, int threshold, int comparisonResult)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(comparisonResult);

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotLessThanOrEqualTo_NoneNullable_WithGreaterValue_DoesNothing()
   {
      // Arrange
      int value = 6;
      int threshold = 5;

      _comparer
         .Setup(c => c.Compare(value, threshold))
         .Returns(1);

      // Act
      IAssert result = AssertExtensions.IsNotLessThanOrEqualTo(_assert.Object, value, threshold, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, threshold), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
