namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
	#region Constants
	private const string IsGreaterThanWithComparerFormat = "{3} was expected to be greater than (>) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
	private const string IsGreaterThanOrEqualToWithComparerFormat = "{3} was expected to be greater than or equal to (>=) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
	private const string IsNotGreaterThanWithComparerFormat = "{3} was expected to not be greater than (<=) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
	private const string IsNotGreaterThanOrEqualToWithComparerFormat = "{3} was expected to not be greater than or equal to (<) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
	#endregion

	#region IsGreaterThan methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is greater than (>) the 
	///   <paramref name="threshold"/> using the given <paramref name="comparer"/>.
	///   </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
	/// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsGreaterThan<T>(
	   this IAssert assert,
	   [DisallowNull] T? value,
	   [DisallowNull] T? threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		int comparison = comparer.Compare(value.Value, threshold.Value);

		if (comparison <= 0)
			assert.Fail(IsGreaterThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsGreaterThan{T}(IAssert, T?, T?, IComparer{T}?, string, string, string, int)"/>
	public static IAssert IsGreaterThan<T>(
	   this IAssert assert,
	   [DisallowNull] T value,
	   [DisallowNull] T threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	{
		int comparison = comparer.Compare(value, threshold);

		if (comparison <= 0)
			assert.Fail(IsGreaterThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}
	#endregion

	#region IsGreaterThanOrEqualTo methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is greater than or equal to
	///   (>=) the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
	/// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than or equal to.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsGreaterThanOrEqualTo<T>(
	   this IAssert assert,
	   [DisallowNull] T? value,
	   [DisallowNull] T? threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		int comparison = comparer.Compare(value.Value, threshold.Value);

		if (comparison < 0)
			assert.Fail(IsGreaterThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsGreaterThanOrEqualTo{T}(IAssert, T?, T?, IComparer{T}?, string, string, string, int)"/>
	public static IAssert IsGreaterThanOrEqualTo<T>(
	   this IAssert assert,
	   [DisallowNull] T value,
	   [DisallowNull] T threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	{
		int comparison = comparer.Compare(value, threshold);

		if (comparison < 0)
			assert.Fail(IsGreaterThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}
	#endregion

	#region IsNotGreaterThan methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is not greater than (&lt;=) 
	///   the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
	/// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNotGreaterThan<T>(
	   this IAssert assert,
	   [DisallowNull] T? value,
	   [DisallowNull] T? threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		int comparison = comparer.Compare(value.Value, threshold.Value);

		if (comparison > 0)
			assert.Fail(IsNotGreaterThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsNotGreaterThan{T}(IAssert, T?, T?, IComparer{T}?, string, string, string, int)"/>
	public static IAssert IsNotGreaterThan<T>(
	   this IAssert assert,
	   [DisallowNull] T value,
	   [DisallowNull] T threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	{
		int comparison = comparer.Compare(value, threshold);

		if (comparison > 0)
			assert.Fail(IsNotGreaterThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}
	#endregion

	#region IsGreaterThanOrEqualTo methods
	/// <summary>
	///   Asserts that the given <paramref name="value"/> is not greater than or equal to 
	///   (&lt;) the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
	/// </summary>
	/// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
	/// <param name="assert">The assertion instance.</param>
	/// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
	/// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than or equal to.</param>
	/// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
	/// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
	/// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
	/// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
	/// <param name="line">The line in the source file where this assertion was made.</param>
	/// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
	public static IAssert IsNotGreaterThanOrEqualTo<T>(
	   this IAssert assert,
	   [DisallowNull] T? value,
	   [DisallowNull] T? threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	   where T : struct
	{
		int comparison = comparer.Compare(value.Value, threshold.Value);

		if (comparison >= 0)
			assert.Fail(IsNotGreaterThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}

	/// <inheritdoc cref="IsNotGreaterThanOrEqualTo{T}(IAssert, T?, T?, IComparer{T}?, string, string, string, int)"/>
	public static IAssert IsNotGreaterThanOrEqualTo<T>(
	   this IAssert assert,
	   [DisallowNull] T value,
	   [DisallowNull] T threshold,
	   [DisallowNull] IComparer<T>? comparer,
	   [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
	   [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
	   [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
	   [CallerLineNumber] int line = 0)
	{
		int comparison = comparer.Compare(value, threshold);
		if (comparison >= 0)
			assert.Fail(IsNotGreaterThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

		return assert;
	}
	#endregion
}

