namespace Testing.Assertions.Tests.EqualityAsserts;

[TestClass]
public sealed class AreSameInstanceAssertTests
{
   #region Fields
   private readonly Mock<IAssert> _assert = new Mock<IAssert>();
   #endregion

   #region AreSameInstance tests
   [TestMethod]
   public void AreSameInstance_WithBothInstancesNull_DoesNothing()
   {
      // Arrange
      object? value = null;
      object? expected = null;

      // Act
      IAssert result = AssertExtensions.AreSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreSameInstance_WithSameInstance_DoesNothing()
   {
      // Arrange
      object? value = new();

      // Act
      IAssert result = AssertExtensions.AreSameInstance(_assert.Object, value, value);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreSameInstance_WithFirstInstanceNull_CallsFail()
   {
      // Arrange
      object? value = null;
      object? expected = new();

      // Act
      IAssert result = AssertExtensions.AreSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreSameInstance_WithSecondInstanceNull_CallsFail()
   {
      // Arrange
      object? value = new();
      object? expected = null;

      // Act
      IAssert result = AssertExtensions.AreSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreSameInstance_WithDifferenceInstances_CallsFail()
   {
      // Arrange
      object? value = new();
      object? expected = new();

      // Act
      IAssert result = AssertExtensions.AreSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion

   #region AreNotSameInstance tests
   [TestMethod]
   public void AreNotSameInstance_WithBothInstancesNull_CallsFail()
   {
      // Arrange
      object? value = null;
      object? expected = null;

      // Act
      IAssert result = AssertExtensions.AreNotSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotSameInstance_WithSameInstance_CallsFail()
   {
      // Arrange
      object? value = new();

      // Act
      IAssert result = AssertExtensions.AreNotSameInstance(_assert.Object, value, value);

      // Assert
      _assert.VerifyFailFormat(Times.Once());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotSameInstance_WithFirstInstanceNull_DoesNothing()
   {
      // Arrange
      object? value = null;
      object? expected = new();

      // Act
      IAssert result = AssertExtensions.AreNotSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotSameInstance_WithSecondInstanceNull_DoesNothing()
   {
      // Arrange
      object? value = new();
      object? expected = null;

      // Act
      IAssert result = AssertExtensions.AreNotSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }

   [TestMethod]
   public void AreNotSameInstance_WithDifferenceInstances_DoesNothing()
   {
      // Arrange
      object? value = new();
      object? expected = new();

      // Act
      IAssert result = AssertExtensions.AreNotSameInstance(_assert.Object, value, expected);

      // Assert
      _assert.VerifyFailFormat(Times.Never());
      _assert.VerifyNoOtherCalls();

      MSAssert.AreSame(_assert.Object, result);
   }
   #endregion
}
