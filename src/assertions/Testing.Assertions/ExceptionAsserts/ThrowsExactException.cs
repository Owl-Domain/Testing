namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string ThrowsExactExceptionNoExceptionFormat = "{2} was expected to throw an exception that is exactly of the type {1} when invoked, but no exception occurred.\nAction: {0}\nLine: {3}";
   private const string ThrowsExactExceptionWrongTypeFormat = "{4} was expected to throw an exception that is exactly of the type {1} when invoked, but it threw an exception of the type {3} instead.\nAction: {0}\nException: {2}\nLine: {5}";
   #endregion

   #region Methods
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
      }
      catch (Exception exception)
      {
         if (exception.GetType() != typeof(T))
            assert.Fail(ThrowsExactExceptionWrongTypeFormat, action, typeof(T), exception, exception.GetType(), actionArgument, line);

         return assert;
      }

      assert.Fail(ThrowsExactExceptionNoExceptionFormat, action, typeof(T), actionArgument, line);
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
      }
      catch (Exception ex)
      {
         if (ex.GetType() != typeof(T))
         {
            assert.Fail(ThrowsExactExceptionWrongTypeFormat, action, typeof(T), ex, ex.GetType(), actionArgument, line);
            exception = null;
         }
         else
            exception = (T)ex;

         return assert;
      }

      assert.Fail(ThrowsExactExceptionNoExceptionFormat, action, typeof(T), actionArgument, line);

      exception = null;
      return assert;
   }
   #endregion
}
