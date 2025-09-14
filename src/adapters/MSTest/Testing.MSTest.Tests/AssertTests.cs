using OwlDomain.Testing.Base;
using Assert = OwlDomain.Testing.MSTest.Assert;

namespace Testing.MSTest.Tests;

[TestClass]
public sealed class AssertTests
{
	#region Tests
	[TestMethod]
	public void Assert_That_ReturnsFailAssert()
	{
		// Arrange
		IAssert value = Assert.That;

		// Assert
		MSAssert.IsInstanceOfType<FailAssert>(value);
	}

	[TestMethod]
	public void Assert_IsConclusiveIf_ReturnsInconclusiveAssert()
	{
		// Arrange
		IAssert value = Assert.IsConclusiveIf;

		// Assert
		MSAssert.IsInstanceOfType<InconclusiveAssert>(value);
	}
	#endregion
}
