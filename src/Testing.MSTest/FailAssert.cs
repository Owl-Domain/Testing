using System.Diagnostics.CodeAnalysis;

namespace OwlDomain.Testing.MSTest;

/// <summary>
/// Represents an <see cref="IAssert"/> implementation which will mark the tests as failed.
/// </summary>
public sealed class FailAssert : IAssert
{
   #region Methods
   /// <inheritdoc/>
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string message) => MSAssert.Fail(message);

   /// <inheritdoc/>
   [DoesNotReturn, ExcludeFromCodeCoverage]
   public void Fail(string format, params object?[] arguments)
   {
      string[] newArguments = FormattingHelper.FormatArguments(arguments);
      MSAssert.Fail(format, newArguments);
   }
   #endregion
}
