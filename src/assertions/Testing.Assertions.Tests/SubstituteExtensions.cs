using NSubstitute.ReceivedExtensions;

namespace OwlDomain.Testing.Assertions.Tests;

internal static class SubstituteExtensions
{
	#region Methods
#pragma warning disable NS5000 // Received check.
	public static T ReceivedAtMostOnce<T>(this T substitute) => substitute.Received(Quantity.Within(0, 1));
#pragma warning restore NS5000 // Received check.

	public static void VerifyFailFormatOnce(this IAssert assert) => assert.ReceivedWithAnyArgs(1).Fail(default!, default!);
	public static void VerifyNoFailFormat(this IAssert assert) => assert.DidNotReceiveWithAnyArgs().Fail(default!, default!);
	#endregion
}
