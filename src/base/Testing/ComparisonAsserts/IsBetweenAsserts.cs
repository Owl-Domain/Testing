namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsBetweenFormat = "{3} was expected to be between {4} and {5}, but it was actually {0}.\nMinimum: {1}\nMaximum: {2}\nLine: {6}";
   private const string IsNotBetweenFormat = "{3} was expected to not be between {4} and {5}, but it was actually {0}.\nMinimum: {1}\nMaximum: {2}\nLine: {6}";
   #endregion

   #region IsBetween methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      IComparable<T> value,
      T minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
   {
      bool comparison =
         value.CompareTo(minimum) >= 0 &&
         value.CompareTo(maximum) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum.Value) >= 0 &&
         value.Value.CompareTo(maximum.Value) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum) >= 0 &&
         value.Value.CompareTo(maximum) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum.Value) >= 0 &&
         value.Value.CompareTo(maximum) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum) >= 0 &&
         value.Value.CompareTo(maximum.Value) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsBetween<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.CompareTo(minimum.Value) >= 0 &&
         value.CompareTo(maximum.Value) <= 0;

      if (comparison is false)
         assert.Fail(IsBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }
   #endregion

   #region IsNotBetween methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      IComparable<T> value,
      T minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
   {
      bool comparison =
         value.CompareTo(minimum) < 0 ||
         value.CompareTo(maximum) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum.Value) < 0 ||
         value.Value.CompareTo(maximum.Value) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum) < 0 ||
         value.Value.CompareTo(maximum) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? minimum,
      T maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum.Value) < 0 ||
         value.Value.CompareTo(maximum) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.Value.CompareTo(minimum) < 0 ||
         value.Value.CompareTo(maximum.Value) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not between the 
   ///   (inclusive) <paramref name="minimum"/> value, and the 
   ///   (inclusive) <paramref name="maximum"/> value.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="minimum"/> and <paramref name="maximum"/> values.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="minimum">The (inclusive) minimum value to compare the <paramref name="value"/> against.</param>
   /// <param name="maximum">The (inclusive) maximum value to compare the <paramref name="value"/> against.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="minimumArgument">The argument expression that was passed in as the <paramref name="minimum"/> value.</param>
   /// <param name="maximumArgument">The argument expression that was passed in as the <paramref name="maximum"/> value.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotBetween<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? minimum,
      [DisallowNull] T? maximum,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(minimum))] string minimumArgument = "<minimum>",
      [CallerArgumentExpression(nameof(maximum))] string maximumArgument = "<maximum>",
      [CallerLineNumber] int line = 0)
      where T : struct, IComparable<T>
   {
      bool comparison =
         value.CompareTo(minimum.Value) < 0 ||
         value.CompareTo(maximum.Value) > 0;

      if (comparison is false)
         assert.Fail(IsNotBetweenFormat, value, minimum, maximum, valueArgument, minimumArgument, maximumArgument, line);

      return assert;
   }
   #endregion
}
