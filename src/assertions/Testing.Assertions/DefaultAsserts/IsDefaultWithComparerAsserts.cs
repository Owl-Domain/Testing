namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
	#region Constants
	private const string IsDefaultWithComparerFormat = "{1} was expected to be equal to it's default value, using the comparer {2}, but it was actually {0}.\nComparer:{3}\nLine: {4}";
	private const string IsNotDefaultWithComparerFormat = "{1} was equal to it's default value when it wasn't expected to be, using the comparer {0}.\nComparer: {2}\nLine {3}";
	#endregion

	#region Methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is equal to it's <see langword="default"/> value.
	///   this method uses the given <paramref name="comparer"/> for the equality check.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use when checking the equality.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsDefault<T>(
	   this IAssert assert,
	   T value,
	   IEqualityComparer<T> comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		bool equality = comparer.Equals(value, default);

		if (equality is false)
			assert.Fail(IsDefaultWithComparerFormat, value, comparer, valueArgument, comparerArgument, line);

		return assert;
	}

	/// <summary>
	///   Asserts that the given <paramref name="value"/> is not equal to it's <see langword="default"/> value.
	///   this method uses the given <paramref name="comparer"/> for the equality check.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use when checking the equality.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNotDefault<T>(
	   this IAssert assert,
	   T value,
	   IEqualityComparer<T> comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		bool equality = comparer.Equals(value, default);

		if (equality)
			assert.Fail(IsNotDefaultWithComparerFormat, comparer, valueArgument, comparerArgument, line);

		return assert;
	}
	#endregion
}
