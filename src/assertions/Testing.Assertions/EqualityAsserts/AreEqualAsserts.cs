namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string AreEqualFormat = "{2} was expected to be equal to {3}, but it was actually {0}.\nExpected: {1}\nLine: {4}";
   private const string AreNotEqualFormat = "{2} was equal to {3}, when it wasn't expected to be.\nValue: {0}\nExpected: {1}\nLine: {4}";
   #endregion

   #region Methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> value are considered equal,
   ///   this method uses the <see cref="EqualityComparer{T}.Default"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="expected"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to be equal to the given <paramref name="value"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerLineNumber] int line = 0)
   {
      bool equality = EqualityComparer<T>.Default.Equals(value, expected);

      if (equality == false)
         assert.Fail(AreEqualFormat, value, expected, valueArgument, expectedArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> value are not considered equal,
   ///   this method uses the <see cref="EqualityComparer{T}.Default"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="expected"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to not be equal to the given <paramref name="value"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerLineNumber] int line = 0)
   {
      bool equality = EqualityComparer<T>.Default.Equals(value, expected);

      if (equality)
         assert.Fail(AreNotEqualFormat, value, expected, valueArgument, expectedArgument, line);

      return assert;
   }
   #endregion
}
