#if NET7_0_OR_GREATER

using System.Numerics;

namespace OwlDomain.Testing;

public static partial class AssertExtensions
{
   #region AreEqual methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> 
   ///   value are considered equal, with the given <paramref name="delta"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/>, the <paramref name="expected"/> value and the <paramref name="delta"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to be equal to the given <paramref name="value"/>.</param>
   /// <param name="delta">
   ///   The maximum difference between the <paramref name="value"/> and the 
   ///   <paramref name="expected"/> value. This value should be positive.
   /// </param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="deltaArgument">The argument expression that was passed in as the <paramref name="delta"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : INumber<T>
   {
      T actualDelta = T.Max(value, expected) - T.Min(value, expected);
      bool equality = actualDelta <= delta;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected) - T.Min(value.Value, expected);
      bool equality = actualDelta <= delta;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected.Value) - T.Min(value, expected.Value);
      bool equality = actualDelta <= delta;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
     this IAssert assert,
     T value,
     T expected,
     [DisallowNull] T? delta,
     [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
     [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
     [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
     [CallerLineNumber] int line = 0)
     where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected) - T.Min(value, expected);
      bool equality = actualDelta <= delta.Value;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected.Value) - T.Min(value.Value, expected.Value);
      bool equality = actualDelta <= delta;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected) - T.Min(value.Value, expected);
      bool equality = actualDelta <= delta.Value;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected.Value) - T.Min(value, expected.Value);
      bool equality = actualDelta <= delta.Value;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected.Value) - T.Min(value.Value, expected.Value);
      bool equality = actualDelta <= delta.Value;

      if (equality == false)
         assert.Fail(AreEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }
   #endregion

   #region AreNotEqual methods
   /// <summary>
   ///   Asserts that the given <paramref name="value"/> and the <paramref name="expected"/> 
   ///   value are considered equal, with the given <paramref name="delta"/>.
   /// </summary>
   /// <typeparam name="T">The type of the <paramref name="value"/>, the <paramref name="expected"/> value and the <paramref name="delta"/> value.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="value">The value to check.</param>
   /// <param name="expected">The value that is expected to be equal to the given <paramref name="value"/>.</param>
   /// <param name="delta">
   ///   The maximum difference between the <paramref name="value"/> and the 
   ///   <paramref name="expected"/> value. This value should be positive.
   /// </param>
   /// <param name="valueArgument">The argument expression that was passed in as the <paramref name="value"/>.</param>
   /// <param name="expectedArgument">The argument expression that was passed in as the <paramref name="expected"/>.</param>
   /// <param name="deltaArgument">The argument expression that was passed in as the <paramref name="delta"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : INumber<T>
   {
      T actualDelta = T.Max(value, expected) - T.Min(value, expected);
      bool equality = actualDelta <= delta;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected) - T.Min(value.Value, expected);
      bool equality = actualDelta <= delta;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected.Value) - T.Min(value, expected.Value);
      bool equality = actualDelta <= delta;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      T expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected) - T.Min(value, expected);
      bool equality = actualDelta <= delta.Value;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? expected,
      T delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected.Value) - T.Min(value.Value, expected.Value);
      bool equality = actualDelta <= delta;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      T expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected) - T.Min(value.Value, expected);
      bool equality = actualDelta <= delta.Value;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      T value,
      [DisallowNull] T? expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value, expected.Value) - T.Min(value, expected.Value);
      bool equality = actualDelta <= delta.Value;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }

   /// <inheritdoc cref="AreNotEqual{T}(IAssert, T, T, T, string, string, string, int)"/>
   public static IAssert AreNotEqual<T>(
      this IAssert assert,
      [DisallowNull] T? value,
      [DisallowNull] T? expected,
      [DisallowNull] T? delta,
      [CallerArgumentExpression(nameof(value))] string valueArgument = "<value>",
      [CallerArgumentExpression(nameof(expected))] string expectedArgument = "<expected>",
      [CallerArgumentExpression(nameof(delta))] string deltaArgument = "<delta>",
      [CallerLineNumber] int line = 0)
      where T : struct, INumber<T>
   {
      T actualDelta = T.Max(value.Value, expected.Value) - T.Min(value.Value, expected.Value);
      bool equality = actualDelta <= delta.Value;

      if (equality)
         assert.Fail(AreNotEqualDeltaFormat, value, expected, delta, actualDelta, valueArgument, expectedArgument, deltaArgument, line);

      return assert;
   }
   #endregion
}

#endif