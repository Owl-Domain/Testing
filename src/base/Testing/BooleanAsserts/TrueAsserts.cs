namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsTrueFormat = "{1} was expected to be true, but it was {0} instead.\nLine: {2}";
   private const string IsNotTrueFormat = "{0} was true when it wasn't expected to be.\nLine: {1}";
   #endregion

   #region Methods
   /// <summary>Asserts that the given <paramref name="value"/> is <see langword="true"/>.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsTrue(
      this IAssert assert,
      [DoesNotReturnIf(false)] bool value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is not true)
         assert.Fail(IsTrueFormat, value, valueArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsTrue(IAssert, bool, string, int)"/>
   public static IAssert IsTrue(
      this IAssert assert,
      [DoesNotReturnIf(false), NotNull] bool? value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is not true)
         assert.Fail(IsTrueFormat, value, valueArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not <see langword="true"/>.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotTrue(
      this IAssert assert,
      [DoesNotReturnIf(true)] bool value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is true)
         assert.Fail(IsNotTrueFormat, valueArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotTrue(IAssert, bool, string, int)"/>
   public static IAssert IsNotTrue(
      this IAssert assert,
      [DoesNotReturnIf(true)] bool? value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is true)
         assert.Fail(IsNotTrueFormat, valueArgument, line);

      return assert;
   }
   #endregion
}