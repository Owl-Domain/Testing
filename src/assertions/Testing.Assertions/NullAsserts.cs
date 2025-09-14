namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
	#region Constants
	private const string IsNullFormat = "{1} was expected to be null, but it was {0} instead.\nLine: {2}";
	private const string IsNotNullFormat = "{0} was null when it wasn't expected to be.\nLine: {1}";
	#endregion

	#region Methods
	/// <summary>Asserts that the given <paramref name="value"/> is <see langword="null"/>.</summary>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNull(
	   this IAssert assert,
	   object? value,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerLineNumber] int line = 0)
	{
		if (value is not null)
			assert.Fail(IsNullFormat, value, valueArgument, line);

		return assert;
	}

	/// <summary>Asserts that the given <paramref name="value"/> is not <see langword="null"/>.</summary>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNotNull(
	   this IAssert assert,
	   [NotNull] object? value,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerLineNumber] int line = 0)
	{
		if (value is null)
			assert.Fail(IsNotNullFormat, valueArgument, line);

		return assert;
	}
	#endregion
}
