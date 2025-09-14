namespace OwlDomain.Testing.MSTest;

/// <summary>
/// Represents the class that stores the MSTest specific <see cref="IAssert"/> instances.
/// </summary>
public static class Assert
{
	#region Properties
	/// <summary>An <see cref="IAssert"/> where failed assertions will result in the test being marked as failed.</summary>
	public static IAssert That { get; } = new FailAssert();

	/// <summary>An <see cref="IAssert"/> where failed assertions will result in the test being marked as inconclusive.</summary>
	public static IAssert IsConclusiveIf { get; } = new InconclusiveAssert();
	#endregion
}
