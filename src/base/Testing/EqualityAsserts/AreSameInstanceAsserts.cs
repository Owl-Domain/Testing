namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region Constants
   private const string AreSameInstanceFormat = "{2} was expected to be the same instance as {3}, but it was actually {0}.\nExpected: {1}\nLine: {4}";
   private const string AreNotSameInstanceFormat = "{2} was the same instance as {3}, when it wasn't expected to be.\nValue: {0}\nExpected: {1}\nLine: {4}";
   #endregion

   #region Methods
   /// <summary>
   ///   Asserts that the given instances (<paramref name="value"/> and <paramref name="expected"/>) are referring to the same instance.<br/>
   ///   This check is done through the following steps.
   ///   <list type="number">
   ///      <item>If both <paramref name="value"/> and <paramref name="expected"/> are <see langword="null"/>, they are considered to be the same instance.</item>
   ///      <item>If only one of <paramref name="value"/> and <paramref name="expected"/> is <see langword="null"/>, they are not considered the same instance.</item>
   ///      <item><see cref="object.ReferenceEquals(object?, object?)"/> is used to evaluate whether <paramref name="value"/> and <paramref name="expected"/> are the same instance.</item>
   ///   </list>
   /// </summary>
   /// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
   /// <typeparam name="TExpected">The type of the <paramref name="expected"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The instance that the <paramref name="value"/> is expected to be the same as.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreSameInstance<TValue, TExpected>(
      this IAssert assert,
      TValue? value,
      TExpected? expected,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerLineNumber] int line = 0)
      where TValue : class
      where TExpected : class
   {
      bool equality =
         (value is null && expected is null) ||
         (value is not null && expected is not null && ReferenceEquals(value, expected));

      if (equality is false)
         assert.Fail(AreSameInstanceFormat, value, expected, valueArgument, expectedArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given instances (<paramref name="value"/> and <paramref name="expected"/>) are not referring to the same instance.<br/>
   ///   This check is done through the following steps.
   ///   <list type="number">
   ///      <item>If both <paramref name="value"/> and <paramref name="expected"/> are <see langword="null"/>, they are considered to be the same instance.</item>
   ///      <item>If only one of <paramref name="value"/> and <paramref name="expected"/> is <see langword="null"/>, they are not considered the same instance.</item>
   ///      <item><see cref="object.ReferenceEquals(object?, object?)"/> is used to evaluate whether <paramref name="value"/> and <paramref name="expected"/> are the same instance.</item>
   ///   </list>
   /// </summary>
   /// <typeparam name="TValue">The type of the <paramref name="value"/>.</typeparam>
   /// <typeparam name="TExpected">The type of the <paramref name="expected"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The instance that the <paramref name="value"/> is expected to be the same as.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreNotSameInstance<TValue, TExpected>(
      this IAssert assert,
      TValue? value,
      TExpected? expected,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerLineNumber] int line = 0)
      where TValue : class
      where TExpected : class
   {
      bool equality =
         (value is null && expected is null) ||
         (value is not null && expected is not null && ReferenceEquals(value, expected));

      if (equality)
         assert.Fail(AreNotSameInstanceFormat, value, valueArgument, expectedArgument, line);

      return assert;
   }
   #endregion
}
