namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
   #region Constants
   private const string ThrowsAnyExceptionFormat = "{1} was expected to throw an exception of any type when invoked, but no exception occurred.\nAction: {0}\nLine: {2}";
   #endregion

   #region Methods
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
      }
      catch
      {
         return assert;
      }

      assert.Fail(ThrowsAnyExceptionFormat, action, actionArgument, line);
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
      }
      catch (Exception ex)
      {
         exception = ex;
         return assert;
      }

      assert.Fail(ThrowsAnyExceptionFormat, action, actionArgument, line);
      exception = null;

      return assert;
   }
   #endregion
}
