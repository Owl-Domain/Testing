namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string HasFlagFormat = "{2} did not have the {3} flag set when it was expected to have it.\nValue: {0}\nFlag: {1}\nLine: {4}";
   private const string DoesNotHaveFlagFormat = "{2} had the {3} flag set when it wasn't expected to have it.\nValue: {0}\nFlag: {1}\nLine: {4}";
   #endregion

   #region HasFlag methods
   /// <summary>
   ///   Asserts that the given enum <paramref name="value"/> has the given <paramref name="flag"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="flag"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="flag">The flag that is expected to be set on the given <paramref name="value"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="flagArgument">The argument expression that was passed in as the <paramref name="flag"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert HasFlag<T>(
      this IAssert assert,
      T value,
      T flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.HasFlag(flag);

      if (result is false)
         assert.Fail(HasFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="HasFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert HasFlag<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.Value.HasFlag(flag);

      if (result is false)
         assert.Fail(HasFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="HasFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert HasFlag<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.HasFlag(flag.Value);

      if (result is false)
         assert.Fail(HasFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="HasFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert HasFlag<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.Value.HasFlag(flag.Value);

      if (result is false)
         assert.Fail(HasFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }
   #endregion

   #region HasFlag methods
   /// <summary>
   ///   Asserts that the given enum <paramref name="value"/> does not have the given <paramref name="flag"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/> and the <paramref name="flag"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="flag">The flag that is expected to not be set on the given <paramref name="value"/>.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="flagArgument">The argument expression that was passed in as the <paramref name="flag"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert DoesNotHaveFlag<T>(
      this IAssert assert,
      T value,
      T flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.HasFlag(flag);

      if (result)
         assert.Fail(DoesNotHaveFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="DoesNotHaveFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert DoesNotHaveFlag<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.Value.HasFlag(flag);

      if (result)
         assert.Fail(DoesNotHaveFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="DoesNotHaveFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert DoesNotHaveFlag<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.HasFlag(flag.Value);

      if (result)
         assert.Fail(DoesNotHaveFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }

   /// <inheritdoc cref="DoesNotHaveFlag{T}(IAssert, T, T, string, string, int)"/>
   public static IAssert DoesNotHaveFlag<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? flag,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(flag))] string flagArgument = "<flag>",
      [CallerLineNumber] int line = 0)
      where T : struct, Enum
   {
      bool result = value.Value.HasFlag(flag.Value);

      if (result)
         assert.Fail(DoesNotHaveFlagFormat, value, flag, valueArgument, flagArgument, line);

      return assert;
   }
   #endregion
}
