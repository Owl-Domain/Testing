namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
	#region Constants
	private const string IsBetweenWithComparerFormat = "{4} was expected to be between {5} and {6}, using the comparer {7}, but it was actually {0}.\nMinimum: {1}\nMaximum: {2}\nComparer: {3}\nLine: {8}";
	private const string IsNotBetweenWithComparerFormat = "{4} was expected to not be between {5} and {6}, using the comparer {7}, but it was actually {0}.\nMinimum: {1}\nMaximum: {2}\nComparer: {3}\nLine: {8}";
	#endregion

	#region IsBetween methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is between the 
	///   (inclusive) <paramref name="minimum"/> value, and the 
	///   (inclusive) <paramref name="maximum"/> value
	///   using the given <paramref name="comparer"/>.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
	/// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
	/// <param name="comparer">
	///   The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against 
	///   the <paramref name="minimum"/> and the <paramref name="maximum"/> values.
	/// </param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
	/// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/> value.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsBetween<T>(
	   this IAssert assert,
	   [DisallowNull] T? value,
	   [DisallowNull] T? minimum,
	   [DisallowNull] T? maximum,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
	   [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		bool comparison =
		   comparer.Compare(value.Value, minimum.Value) >= 0 &&
		   comparer.Compare(value.Value, maximum.Value) <= 0;

		if (comparison is false)
			assert.Fail(IsBetweenWithComparerFormat, value, minimum, maximum, comparer, valueArgument, minimumArgument, maximumArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsBetween{T}(IAssert, T?, T?, T?, IComparer{T}?, string, string, string, string, int)"/>
	public static IAssert IsBetween<T>(
	   this IAssert assert,
	   [DisallowNull] T value,
	   [DisallowNull] T minimum,
	   [DisallowNull] T maximum,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
	   [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	{
		bool comparison =
		   comparer.Compare(value, minimum) >= 0 &&
		   comparer.Compare(value, maximum) <= 0;

		if (comparison is false)
			assert.Fail(IsBetweenWithComparerFormat, value, minimum, maximum, comparer, valueArgument, minimumArgument, maximumArgument, comparerArgument, line);

		return assert;
	}
	#endregion

	#region IsNotBetween methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is not between the 
	///   (inclusive) <paramref name="minimum"/> value, and the 
	///   (inclusive) <paramref name="maximum"/> value
	///   using the given <paramref name="comparer"/>.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check.</param>
	/// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
	/// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
	/// <param name="comparer">
	///   The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against 
	///   the <paramref name="minimum"/> and the <paramref name="maximum"/> values.
	/// </param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
	/// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/> value.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNotBetween<T>(
		  this IAssert assert,
		  [DisallowNull] T? value,
		  [DisallowNull] T? minimum,
		  [DisallowNull] T? maximum,
		  [DisallowNull] IComparer<T>? comparer,
		  [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
		  [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
		  [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
		  [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
		  [CallerLineNumber] int line = 0)
	   where T : struct
	{
		bool comparison =
		   comparer.Compare(value.Value, minimum.Value) >= 0 &&
		   comparer.Compare(value.Value, maximum.Value) <= 0;

		if (comparison)
			assert.Fail(IsNotBetweenWithComparerFormat, value, minimum, maximum, comparer, valueArgument, minimumArgument, maximumArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsNotBetween{T}(IAssert, T?, T?, T?, IComparer{T}?, string, string, string, string, int)"/>
	public static IAssert IsNotBetween<T>(
		  this IAssert assert,
		  [DisallowNull] T value,
		  [DisallowNull] T minimum,
		  [DisallowNull] T maximum,
		  [DisallowNull] IComparer<T>? comparer,
		  [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
		  [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
		  [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
		  [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
		  [CallerLineNumber] int line = 0)
	{
		bool comparison =
		   comparer.Compare(value, minimum) >= 0 &&
		   comparer.Compare(value, maximum) <= 0;

		if (comparison)
			assert.Fail(IsNotBetweenWithComparerFormat, value, minimum, maximum, comparer, valueArgument, minimumArgument, maximumArgument, comparerArgument, line);

		return assert;
	}
	#endregion
}
