namespace OwlDomain.Testing.MSTest;

/// <summary>
/// Represents an <see cref="IAssert"/> implementation which will mark the tests as failed.
/// </summary>
public sealed class FailAssert : IAssert
{
   #region Methods
   /// <inheritdoc/>
   [DoesNotReturn]
   public void Fail(string message) => throw new AssertFailedException(message);

   /// <inheritdoc/>
   [DoesNotReturn]
   public void Fail([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      string message = string.Format(format, newArguments);

      throw new AssertFailedException(message);
   }
   #endregion
}
