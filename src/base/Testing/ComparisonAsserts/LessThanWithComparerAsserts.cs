namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsLessThanWithComparerFormat = "{3} was expected to be less than (<) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
   private const string IsLessThanOrEqualToWithComparerFormat = "{3} was expected to be less than or equal to (<=) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
   private const string IsNotLessThanWithComparerFormat = "{3} was expected to not be less than (>=) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
   private const string IsNotLessThanOrEqualToWithComparerFormat = "{3} was expected to not be less than or equal to (<) {4}, using the comparer {5}, but it was actually {0}.\nThreshold: {1}\nComparer: {2}\nLine: {6}";
   #endregion

   #region IsLessThan methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is less than (&lt;) the 
   ///   <paramref name="threshold"/> using the given <paramref name="comparer"/>.
   ///   </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be less than.</param>
   /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsLessThan<T>(
      this IAssert assert,
      T value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = comparer.Compare(value, threshold);

      if (comparison >= 0)
         assert.Fail(IsLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThan{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold.Value);

      if (comparison >= 0)
         assert.Fail(IsLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThan{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold);

      if (comparison >= 0)
         assert.Fail(IsLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }
   #endregion

   #region IsLessThanOrEqualTo methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is less than or equal to
   ///   (&lt;=) the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be less than or equal to.</param>
   /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsLessThanOrEqualTo<T>(
      this IAssert assert,
      T value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = comparer.Compare(value, threshold);

      if (comparison > 0)
         assert.Fail(IsLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThanOrEqualTo{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold.Value);

      if (comparison > 0)
         assert.Fail(IsLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThanOrEqualTo{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold);

      if (comparison > 0)
         assert.Fail(IsLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }
   #endregion

   #region IsNotLessThan methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not less than (>=) 
   ///   the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be less than.</param>
   /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotLessThan<T>(
      this IAssert assert,
      T value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = comparer.Compare(value, threshold);

      if (comparison < 0)
         assert.Fail(IsNotLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThan{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsNotLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold.Value);

      if (comparison < 0)
         assert.Fail(IsNotLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThan{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsNotLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold);

      if (comparison < 0)
         assert.Fail(IsNotLessThanWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }
   #endregion

   #region IsLessThanOrEqualTo methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not less than or equal to 
   ///   (>) the <paramref name="threshold"/> using the given <paramref name="comparer"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be less than or equal to.</param>
   /// <param name="comparer">The <see cref="IComparer{T}"/> used to compare the <paramref name="value"/> against the <paramref name="threshold"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotLessThanOrEqualTo<T>(
      this IAssert assert,
      T value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = comparer.Compare(value, threshold);

      if (comparison <= 0)
         assert.Fail(IsNotLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThanOrEqualTo{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsNotLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold.Value);

      if (comparison <= 0)
         assert.Fail(IsNotLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThanOrEqualTo{T}(IAssert, T, T, IComparer{T}, string, string, string, int)"/>
   public static IAssert IsNotLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      IComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      int comparison = comparer.Compare(value.Value, threshold);

      if (comparison <= 0)
         assert.Fail(IsNotLessThanOrEqualToWithComparerFormat, value, threshold, comparer, valueArgument, thresholdArgument, comparerArgument, line);

      return assert;
   }
   #endregion
}
