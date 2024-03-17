namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string ThrowsAnyExceptionFormat = "{1} was expected to throw an exception of any type when invoked, but no exception occurred.\nAction: {0}\nLine: {2}";

   private const string ThrowsExceptionOfTypeNoExceptionFormat = "{2} was expected to throw an exception of the type {1} or a derived type when invoked, but no exception occurred.\nAction: {0}\nLine: {3}";
   private const string ThrowsExceptionOfTypeWrongTypeFormat = "{4} was expected to throw an exception of the type {1} or a derived type when invoked, but it threw an exception of the type {3} instead.\nAction: {0}\nException: {2}\nLine: {5}";

   private const string ThrowsExactExceptionNoExceptionFormat = "{2} was expected to throw an exception that is exactly of the type {1} when invoked, but no exception occurred.\nAction: {0}\nLine: {3}";
   private const string ThrowsExactExceptionWrongTypeFormat = "{4} was expected to throw an exception that is exactly of the type {1} when invoked, but it threw an exception of the type {3} instead.\nAction: {0}\nException: {2}\nLine: {5}";

   private const string DoesNotThrowAnyExceptionFormat = "{3} was expect to not throw any exceptions when invoked, but it threw an exception of the type {2}.\nAction: {0}\nException: {1}\nLine: {4}";
   #endregion

   #region ThrowsException methods
   /// <summary>Asserts that the given <paramref name="action"/> throws any type of an <see cref="Exception"/> when invoked.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsAnyException(
      this IAssert assert,
      Action action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsAnyExceptionFormat, action, actionArgument, line);
      }
      catch { }

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="action"/> throws any type of an <see cref="Exception"/> when invoked.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="exception">The exception that was thrown.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsAnyException(
      this IAssert assert,
      Action action,
      out Exception exception,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsAnyExceptionFormat, action, actionArgument, line);

         exception = null;
      }
      catch (Exception ex)
      {
         exception = ex;
      }

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="action"/> throws an <see cref="Exception"/>
   ///   that is of the type <typeparamref name="T"/> or a derived type when invoked.
   /// </summary>
   /// <typeparam name="T">The type of the <see cref="Exception"/> to check for.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsExceptionOfType<T>(
      this IAssert assert,
      Action action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
      where T : notnull, Exception
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsExceptionOfTypeNoExceptionFormat, action, typeof(T), actionArgument, line);
      }
      catch (Exception exception)
      {
         if (exception is not T)
            assert.Fail(ThrowsExceptionOfTypeWrongTypeFormat, action, typeof(T), exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="action"/> throws an <see cref="Exception"/>
   ///   that is of the type <typeparamref name="T"/> or a derived type when invoked.
   /// </summary>
   /// <typeparam name="T">The type of the <see cref="Exception"/> to check for.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="exception">The exception that was thrown.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsExceptionOfType<T>(
      this IAssert assert,
      Action action,
      out T exception,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
      where T : notnull, Exception
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsExceptionOfTypeNoExceptionFormat, action, typeof(T), actionArgument, line);

         // Note(Nightowl): Never reached;
         exception = null;
      }
      catch (Exception ex)
      {
         if (ex is not T typedException)
         {
            assert.Fail(ThrowsExceptionOfTypeWrongTypeFormat, action, typeof(T), ex, ex.GetType(), actionArgument, line);

            // Note(Nightowl): Never reached;
            exception = null;
         }
         else
            exception = typedException;
      }

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="action"/> throws an <see cref="Exception"/>
   ///   that is exactly of the type <typeparamref name="T"/> when invoked.
   /// </summary>
   /// <typeparam name="T">The type of the <see cref="Exception"/> to check for.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsExactException<T>(
      this IAssert assert,
      Action action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
      where T : notnull, Exception
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsExactExceptionNoExceptionFormat, action, typeof(T), actionArgument, line);
      }
      catch (Exception exception)
      {
         if (exception.GetType() != typeof(T))
            assert.Fail(ThrowsExactExceptionWrongTypeFormat, action, typeof(T), exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }

   /// <summary>
   ///   Asserts that the given <paramref name="action"/> throws an <see cref="Exception"/>
   ///   that is exactly of the type <typeparamref name="T"/> when invoked.
   /// </summary>
   /// <typeparam name="T">The type of the <see cref="Exception"/> to check for.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="exception">The exception that was thrown.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert ThrowsExactException<T>(
      this IAssert assert,
      Action action,
      out T exception,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
      where T : notnull, Exception
   {
      try
      {
         action.Invoke();

         assert.Fail(ThrowsExactExceptionNoExceptionFormat, action, typeof(T), actionArgument, line);

         // Note(Nightowl): Never reached;
         exception = null;
      }
      catch (Exception ex)
      {
         if (ex.GetType() != typeof(T))
         {
            assert.Fail(ThrowsExactExceptionWrongTypeFormat, action, typeof(T), ex, ex.GetType(), actionArgument, line);

            // Note(Nightowl): Never reached;
            exception = null;
         }
         else
            exception = (T)ex;
      }

      return assert;
   }
   #endregion

   #region DoesNotThrowException methods
   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert DoesNotThrowAnyException(
      this IAssert assert,
      Action action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         action.Invoke();
      }
      catch (Exception exception)
      {
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }
   #endregion
}
