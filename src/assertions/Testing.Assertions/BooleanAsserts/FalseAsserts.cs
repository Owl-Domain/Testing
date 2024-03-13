namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsFalseFormat = "{1} was expected to be false, but it was {0} instead.\nLine: {2}";
   private const string IsNotFalseFormat = "{0} was false when it wasn't expected to be.\nLine: {1}";
   #endregion

   #region Methods
   /// <summary>Asserts that the given <paramref name="value"/> is <see langword="false"/>.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsFalse(
      this IAssert assert,
      [DoesNotReturnIf(true)] bool value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is not false)
         assert.Fail(IsFalseFormat, value, valueArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsFalse(IAssert, bool, string, int)"/>
   public static IAssert IsFalse(
      this IAssert assert,
      [DoesNotReturnIf(true), NotNull] bool? value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is not false)
         assert.Fail(IsFalseFormat, value, valueArgument, line);

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="value"/> is not <see langword="false"/>.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotFalse(
      this IAssert assert,
      [DoesNotReturnIf(false)] bool value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is false)
         assert.Fail(IsNotFalseFormat, valueArgument, line);

      return assert;
   }

   /// <inheritdoc cref="IsNotFalse(IAssert, bool, string, int)"/>
   public static IAssert IsNotFalse(
      this IAssert assert,
      [DoesNotReturnIf(false)] bool? value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
   {
      if (value is false)
         assert.Fail(IsNotFalseFormat, valueArgument, line);

      return assert;
   }
   #endregion
}