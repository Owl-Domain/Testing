namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string IsDefaultFormat = "{1} was expected to be equal to it's default value, but it was actually {0}.\nLine: {2}";
   private const string IsNotDefaultFormat = "{0} was equal to it's default value when it wasn't expected to be.\nLine {1}";
   #endregion

   #region Methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is equal to it's <see langword="default"/> value,
   ///   this method uses the <see cref="EqualityComparer{T}.Default"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsDefault<T>(
      this IAssert assert,
      T value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      bool equality = EqualityComparer<T>.Default.Equals(value, default);

      if (equality is false)
         assert.Fail(IsDefaultFormat, value, valueArgument, line);

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="value"/> is not equal to it's <see langword="default"/> value,
   ///   this method uses the <see cref="EqualityComparer{T}.Default"/> for the equality check.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/>.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert IsNotDefault<T>(
      this IAssert assert,
      T value,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerLineNumber] int line = 0)
      where T : struct
   {
      bool equality = EqualityComparer<T>.Default.Equals(value, default);

      if (equality)
         assert.Fail(IsNotDefaultFormat, valueArgument, line);

      return assert;
   }
   #endregion
}
