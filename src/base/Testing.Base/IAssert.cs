namespace OwlDomain.Testing.Base;

/// <summary>
/// Represents an assertion capable of throwing failed assertions.
/// </summary>
public interface IAssert
{
   #region Methods
   /// <summary>Throws a failed assertion with the given <paramref name="message"/>.</summary>
   /// <param name="message">The message for the failed assertion.</param>
   [DoesNotReturn]
   void Fail(string message);

   /// <summary>Throws a failed assertion with a message generated from the given <paramref name="format"/> and the <paramref name="arguments"/>.</summary>
   /// <param name="format">The format of the failed assertion to fill with the given <paramref name="arguments"/>.</param>
   /// <param name="arguments">The arguments to use along with the message <paramref name="format"/>.</param>
   [DoesNotReturn]
   void Fail([StringSyntax(StringSyntaxAttribute.CompositeFormat)] string format, params object?[] arguments);
   #endregion
}
