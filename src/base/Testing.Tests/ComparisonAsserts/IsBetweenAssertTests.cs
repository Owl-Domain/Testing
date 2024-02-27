namespace Testing.Tests.ComparisonAsserts;

[TestClass]
public class IsBetweenAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region IsBetween tests
   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_Comparable_WithValueInRange_DoesNothing(IComparable<int> value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_Comparable_WithValueOutsideRange_CallsFail(IComparable<int> value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_AllNullable_WithValueInRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_AllNullable_WithValueOutsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueNullable_WithValueInRange_DoesNothing([DisallowNull] int? value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_ValueNullable_WithValueOutsideRange_CallsFail([DisallowNull] int? value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMinimumNullable_WithValueInRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMinimumNullable_WithValueOutsideRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMaximumNullable_WithValueInRange_DoesNothing([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_ValueAndMaximumNullable_WithValueOutsideRange_CallsFail([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsBetween_MinimumAndMaximumNullable_WithValueInRange_DoesNothing(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsBetween_MinimumAndMaximumNullable_WithValueOutsideRange_CallsFail(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion

   #region IsNotBetween tests
   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_Comparable_WithValueInRange_CallsFail(IComparable<int> value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_Comparable_WithValueOutsideRange_DoesNothing(IComparable<int> value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_AllNullable_WithValueInRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_AllNullable_WithValueOutsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueNullable_WithValueInRange_CallsFail([DisallowNull] int? value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_ValueNullable_WithValueOutsideRange_DoesNothing([DisallowNull] int? value, int minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMinimumNullable_WithValueInRange_CallsFail([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMinimumNullable_WithValueOutsideRange_DoesNothing([DisallowNull] int? value, [DisallowNull] int? minimum, int maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMaximumNullable_WithValueInRange_CallsFail([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_ValueAndMaximumNullable_WithValueOutsideRange_DoesNothing([DisallowNull] int? value, int minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(5, 0, 10, DisplayName = "In-between")]
   [DataRow(0, 0, 10, DisplayName = "Same as minimum")]
   [DataRow(10, 0, 10, DisplayName = "Same as maximum")]
   [TestMethod]
   public void IsNotBetween_MinimumAndMaximumNullable_WithValueInRange_CallsFail(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }

   [DataRow(-1, 0, 10, DisplayName = "Below minimum")]
   [DataRow(11, 0, 10, DisplayName = "Above maximum")]
   [TestMethod]
   public void IsNotBetween_MinimumAndMaximumNullable_WithValueOutsideRange_DoesNothing(int value, [DisallowNull] int? minimum, [DisallowNull] int? maximum)
   {
      // Act
      IAssert result = AssertExtensions.IsNotBetween(_assert.Object, value, minimum, maximum);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreEqual(_assert.Object, result);
   }
   #endregion
}