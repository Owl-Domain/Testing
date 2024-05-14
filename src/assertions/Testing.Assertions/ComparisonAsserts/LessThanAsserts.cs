namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsLessThanFormat = "{2} was expected to be less than (<) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsLessThanOrEqualToFormat = "{2} was expected to be less than or equal to (<=) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsNotLessThanFormat = "{2} was expected to not be less than (>=) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsNotLessThanOrEqualToFormat = "{2} was expected to not be less than or equal to (>) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   #endregion

   #region IsLessThan methods
   /// <summary>Asserts that the given <paramref name="value"/> is less than (&lt;) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be less than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold.Value);

      if (comparison >= 0)
         assert.Fail(IsLessThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThan{T}(IAssert, T?, T?, string, string, int)"/>
   public static IAssert IsLessThan<T>(
      this IAssert assert,
      [DisallowNull] T value,
      [DisallowNull] T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : IComparable<T>
   {
      int comparison = value.CompareTo(threshold);

      if (comparison >= 0)
         assert.Fail(IsLessThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsLessThanOrEqualTo methods
   /// <summary>Asserts that the given <paramref name="value"/> is less than or equal to (&lt;=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be less than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold.Value);

      if (comparison > 0)
         assert.Fail(IsLessThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsLessThanOrEqualTo{T}(IAssert, T?, T?, string, string, int)"/>
   public static IAssert IsLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T value,
      [DisallowNull] T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : IComparable<T>
   {
      int comparison = value.CompareTo(threshold);

      if (comparison > 0)
         assert.Fail(IsLessThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsNotLessThan methods
   /// <summary>Asserts that the given <paramref name="value"/> is not less than (>=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be less than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotLessThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold.Value);

      if (comparison < 0)
         assert.Fail(IsNotLessThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThan{T}(IAssert, T?, T?, string, string, int)"/>
   public static IAssert IsNotLessThan<T>(
      this IAssert assert,
      [DisallowNull] T value,
      [DisallowNull] T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : IComparable<T>
   {
      int comparison = value.CompareTo(threshold);

      if (comparison < 0)
         assert.Fail(IsNotLessThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsLessThanOrEqualTo methods
   /// <summary>Asserts that the given <paramref name="value"/> is not less than or equal to (>) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be less than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold.Value);

      if (comparison <= 0)
         assert.Fail(IsNotLessThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotLessThanOrEqualTo{T}(IAssert, T?, T?, string, string, int)"/>
   public static IAssert IsNotLessThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T value,
      [DisallowNull] T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : IComparable<T>
   {
      int comparison = value.CompareTo(threshold);

      if (comparison <= 0)
         assert.Fail(IsNotLessThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion
}
