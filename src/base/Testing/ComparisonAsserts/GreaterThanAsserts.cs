namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsGreaterThanFormat = "{2} was expected to be greater than (>) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsGreaterThanOrEqualToFormat = "{2} was expected to be greater than or equal to (>=) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsNotGreaterThanFormat = "{2} was expected to not be greater than (<=) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   private const string IsNotGreaterThanOrEqualToFormat = "{2} was expected to not be greater than or equal to (<) {3}, but it was actually {0}.\nThreshold: {1}\nLine: {4}";
   #endregion

   #region IsGreaterThan methods
   /// <summary>Asserts that the given <paramref name="value"/> is greater than (>) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThan<T>(
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
         assert.Fail(IsGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is greater than (>) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold);

      if (comparison <= 0)
         assert.Fail(IsGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is greater than (>) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThan<T>(
      this IAssert assert,
      IComparable<T> value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = value.CompareTo(threshold);

      if (comparison <= 0)
         assert.Fail(IsGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsGreaterThanOrEqualTo methods
   /// <summary>Asserts that the given <paramref name="value"/> is greater than or equal to (>=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThanOrEqualTo<T>(
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
         assert.Fail(IsGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is greater than or equal to (>=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold);

      if (comparison < 0)
         assert.Fail(IsGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is greater than or equal to (>=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsGreaterThanOrEqualTo<T>(
      this IAssert assert,
      IComparable<T> value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = value.CompareTo(threshold);

      if (comparison < 0)
         assert.Fail(IsGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsNotGreaterThan methods
   /// <summary>Asserts that the given <paramref name="value"/> is not greater than (&lt;=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThan<T>(
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
         assert.Fail(IsNotGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not greater than (&lt;=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThan<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold);

      if (comparison > 0)
         assert.Fail(IsNotGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not greater than (&lt;=) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThan<T>(
      this IAssert assert,
      IComparable<T> value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = value.CompareTo(threshold);

      if (comparison > 0)
         assert.Fail(IsNotGreaterThanFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion

   #region IsGreaterThanOrEqualTo methods
   /// <summary>Asserts that the given <paramref name="value"/> is not greater than or equal to (&lt;) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThanOrEqualTo<T>(
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
         assert.Fail(IsNotGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not greater than or equal to (&lt;) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThanOrEqualTo<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      int comparison = value.Value.CompareTo(threshold);

      if (comparison >= 0)
         assert.Fail(IsNotGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not greater than or equal to (&lt;) the <paramref name="threshold"/>.</summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="threshold"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check against the <paramref name="threshold"/>.</param>
   /// <param name="threshold">The threshold that the <paramref name="value"/> has to not be greater than or equal to.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="thresholdArgument">The argument expression that was passed in as the <paramref name="threshold"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotGreaterThanOrEqualTo<T>(
      this IAssert assert,
      IComparable<T> value,
      T threshold,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(threshold))] string thresholdArgument = "<threshold>",
      [CallerLineNumber] int line = 0)
   {
      int comparison = value.CompareTo(threshold);

      if (comparison >= 0)
         assert.Fail(IsNotGreaterThanOrEqualToFormat, value, threshold, valueArgument, thresholdArgument, line);

      return assert;
   }
   #endregion
}
