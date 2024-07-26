namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string AreEqualWithComparerFormat = "{3} was expected to be equal to {4}, using the comparer {5}, but it was actually {0}.\nExpected: {1}\nComparer: {2}\nLine: {6}";
   private const string AreNotEqualWithComparerFormat = "{3} was equal to {4}, when it wasn't expected to be, using the comparer {5}.\nValue: {0}\nExpected: {1}\nComparer: {2}\nLine: {6}";
   #endregion

   #region Methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> value are considered equal,
   ///   this method uses the given <paramref name="comparer"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="expected"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to be equal to the given <paramref name="value"/>.</param>
   /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use when checking the equality.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      IEqualityComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      bool equality = comparer.Equals(value, expected);

      if (equality is false)
         assert.Fail(AreEqualWithComparerFormat, value, expected, comparer, valueArgument, expectedArgument, comparerArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> value are not considered equal,
   ///   this method uses the given <paramref name="comparer"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="expected"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to not be equal to the given <paramref name="value"/>.</param>
   /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use when checking the equality.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="comparerArgument">The argument expression that was passed in as the <paramref name="comparer"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      IEqualityComparer<T> comparer,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(comparer))] string comparerArgument = "<comparer>",
      [CallerLineNumber] int line = 0)
   {
      bool equality = comparer.Equals(value, expected);

      if (equality)
         assert.Fail(AreNotEqualWithComparerFormat, value, expected, comparer, valueArgument, expectedArgument, comparerArgument, line);

      return assert;
   }
   #endregion
}
