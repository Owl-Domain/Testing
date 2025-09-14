namespace OwlDomain.Testing.Assertions;

public static partial class AssertExtensions
{
	#region Constants
	private const string AreEqualDeltaFormat = "{4} was expected to be equal to {5} within the delta of {6} but it wasn't.\nValue: {0}\nExpected: {1}\nExpected delta: {2}\nActual delta: {3}\nLine: {7}";
	private const string AreNotEqualDeltaFormat = "{4} was expected to not be equal to {5} within the delta of {6} but it was..\nValue: {0}\nExpected: {1}\nExpected delta: {2}\nActual delta: {3}\nLine: {7}";
	#endregion
}
