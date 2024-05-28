namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string DoesNotThrowAnyExceptionFormat = "{3} was expect to not throw any exceptions when invoked, but it threw an exception of the type {2}.\nAction: {0}\nException: {1}\nLine: {4}";
   #endregion

   #region Methods
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

   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static async ValueTask<IAssert> DoesNotThrowAnyExceptionAsync(
      this IAssert assert,
      Func<ValueTask> action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         await action.Invoke();
      }
      catch (Exception exception)
      {
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static async ValueTask<IAssert> DoesNotThrowAnyExceptionAsync(
      this IAssert assert,
      Func<Task> action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         await action.Invoke();
      }
      catch (Exception exception)
      {
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <typeparam name="T"></typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="result">The result returned by the <paramref name="action"/>.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The <see cref="IAssert"/> instance this extension method was called on to allow for chaining assertions.</returns>
   public static IAssert DoesNotThrowAnyException<T>(
      this IAssert assert,
      Func<T> action,
      out T result,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      try
      {
         result = action.Invoke();
      }
      catch (Exception exception)
      {
         result = default!;
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return assert;
   }

   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <typeparam name="T">The type of the value that the given <paramref name="action"/> returns.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The result returned by the <paramref name="action"/>.</returns>
   public static async ValueTask<T> DoesNotThrowAnyExceptionAsync<T>(
      this IAssert assert,
      Func<ValueTask<T>> action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      T result;
      try
      {
         result = await action.Invoke();
      }
      catch (Exception exception)
      {
         result = default!;
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return result;
   }

   /// <summary>Asserts that the given <paramref name="action"/> does not throw any exception when invoked.</summary>
   /// <typeparam name="T">The type of the value that the given <paramref name="action"/> returns.</typeparam>
   /// <param name="assert">The assertion instance.</param>
   /// <param name="action">The action to check.</param>
   /// <param name="actionArgument">The argument expression that was passed in as the <paramref name="action"/>.</param>
   /// <param name="line">The line in the source file where this assertion was made.</param>
   /// <returns>The result returned by the <paramref name="action"/>.</returns>
   public static async ValueTask<T> DoesNotThrowAnyExceptionAsync<T>(
      this IAssert assert,
      Func<Task<T>> action,
      [CallerArgumentExpression(nameof(action))] string actionArgument = "<action>",
      [CallerLineNumber] int line = 0)
   {
      T result;
      try
      {
         result = await action.Invoke();
      }
      catch (Exception exception)
      {
         result = default!;
         assert.Fail(DoesNotThrowAnyExceptionFormat, action, exception, exception.GetType(), actionArgument, line);
      }

      return result;
   }
   #endregion
}
