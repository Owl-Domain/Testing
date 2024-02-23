using System.Diagnostics.CodeAnalysis;

namespace OwlDomain.Testing.MSTest;

/// <summary>
/// Represents an <see cref="IAssert"/> implementation which will mark the tests as inconclusive.
/// </summary>
public sealed class InconclusiveAssert : IAssert
{
   #region Methods
   /// <inheritdoc/>
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string message) => MSAssert.Inconclusive(message);

   /// <inheritdoc/>
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      MSAssert.Inconclusive(format, newArguments);
   }
   #endregion
}
