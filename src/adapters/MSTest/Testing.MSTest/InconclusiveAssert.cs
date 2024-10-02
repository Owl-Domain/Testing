namespace OwlDomain.Testing.MSTest;

/// <summary>
/// Represents an <see cref="IAssert"/> implementation which will mark the tests as inconclusive.
/// </summary>
public sealed class InconclusiveAssert : IAssert
{
   #region Methods
   /// <inheritdoc/>
   [DoesNotReturn]
   public void Fail(string message) => throw new AssertInconclusiveException(message);

   /// <inheritdoc/>
   [DoesNotReturn]
   public void Fail([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      string message = string.Format(format, newArguments);

      throw new AssertInconclusiveException(message);
   }
   #endregion
}
