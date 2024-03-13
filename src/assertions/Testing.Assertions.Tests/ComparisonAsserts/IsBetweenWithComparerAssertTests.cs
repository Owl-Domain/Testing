namespace Testing.Assertions.Tests.ComparisonAsserts;

[TestClass]
public class IsBetweenWithComparerAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   private readonly Mock<IComparer<int>> _comparer = new Mock<IComparer<int>>();
   #endregion

   #region IsBetween tests
   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_WithValueInsideRange_DoesNothing(int value, int minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int value = -1;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int value = 11;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_AllNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_AllNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int? value = -1;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_AllNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int? value = 11;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, int minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int? value = -1;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int? value = 11;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMinimumNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueAndMinimumNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int? value = -1;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueAndMinimumNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int? value = 11;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMaximumNullable_WithValueInsideRange_DoesNothing([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueAndMaximumNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int? value = -1;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_ValueAndMaximumNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int? value = 11;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_MinimumAndMaximumNullable_WithValueInsideRange_DoesNothing(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MinimumAndMaximumNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int value = -1;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MinimumAndMaximumNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int value = 11;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_MinimumNullable_WithValueInsideRange_DoesNothing(int value, [DisallowNull] int? minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MinimumNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int value = -1;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MinimumNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int value = 11;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_MaximumNullable_WithValueInsideRange_DoesNothing(int value, int minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MaximumNullable_WithValueBelowMinimum_CallsFail()
   {
      // Arrange
      int value = -1;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.Once());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsBetween_MaximumNullable_WithValueAboveMaximum_CallsFail()
   {
      // Arrange
      int value = 11;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.Once());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotBetween tests
   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_WithValueInsideRange_CallsFail(int value, int minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int value = -1;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int value = 11;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_AllNullable_WithValueInsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_AllNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int? value = -1;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_AllNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int? value = 11;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueNullable_WithValueInsideRange_CallsFail([DisallowNull] int? value, int minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int? value = -1;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int? value = 11;
      int minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMinimumNullable_WithValueInsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueAndMinimumNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int? value = -1;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueAndMinimumNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int? value = 11;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum.Value))
         .Returns(value.Value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum))
         .Returns(value.Value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMaximumNullable_WithValueInsideRange_CallsFail([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueAndMaximumNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int? value = -1;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_ValueAndMaximumNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int? value = 11;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value.Value, minimum))
         .Returns(value.Value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value.Value, maximum.Value))
         .Returns(value.Value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value.Value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value.Value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_MinimumAndMaximumNullable_WithValueInsideRange_CallsFail(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MinimumAndMaximumNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int value = -1;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MinimumAndMaximumNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int value = 11;
      int? minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_MinimumNullable_WithValueInsideRange_CallsFail(int value, [DisallowNull] int? minimum, int maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));

      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MinimumNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int value = -1;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MinimumNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int value = 11;
      int? minimum = 0;
      int maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum.Value))
         .Returns(value.CompareTo(minimum.Value));
      _comparer
         .Setup(c => c.Compare(value, maximum))
         .Returns(value.CompareTo(maximum));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum.Value), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_MaximumNullable_WithValueInsideRange_CallsFail(int value, int minimum, [DisallowNull] int? maximum)
   {
      // Arrange
      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));

      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MaximumNullable_WithValueBelowMinimum_DoesNothing()
   {
      // Arrange
      int value = -1;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [TestMethod]
   public void IsNotBetween_MaximumNullable_WithValueAboveMaximum_DoesNothing()
   {
      // Arrange
      int value = 11;
      int minimum = 0;
      int? maximum = 10;

      _comparer
         .Setup(c => c.Compare(value, minimum))
         .Returns(value.CompareTo(minimum));
      _comparer
         .Setup(c => c.Compare(value, maximum.Value))
         .Returns(value.CompareTo(maximum.Value));

      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum, _comparer.Object);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      _comparer.Verify(c => c.Compare(value, minimum), Times.AtMostOnce());
      _comparer.Verify(c => c.Compare(value, maximum.Value), Times.AtMostOnce());
      _comparer.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion
}
