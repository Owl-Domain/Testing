namespace Testing.Base.Tests;

[TestClass]
public sealed class FormattingHelperTests
{
   #region Subclass
   private sealed class Stub(string? toStringResult)
   {
      public override string? ToString() => toStringResult;
   }
   #endregion

   #region Tests
   [TestMethod]
   public void FormatArguments_WithNoArguments_ReturnsEmptyArray()
   {
      // Arrange
      object?[] arguments = [];
      string[] expected = [];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }

   [DataRow(null, "<null>", DisplayName = "Null")]
   [DataRow(true, "true", DisplayName = "Boolean (true)")]
   [DataRow(false, "false", DisplayName = "Boolean (false)")]
   [DataRow('a', "'a'", DisplayName = "Char")]
   [DataRow((sbyte)1, "1sb", DisplayName = "SByte")]
   [DataRow((byte)2, "2b", DisplayName = "Byte")]
   [DataRow((short)3, "3s", DisplayName = "Int16")]
   [DataRow((ushort)4, "4us", DisplayName = "UInt16")]
   [DataRow(5, "5", DisplayName = "Int32")]
   [DataRow(6u, "6u", DisplayName = "UInt32")]
   [DataRow(7L, "7l", DisplayName = "Int64")]
   [DataRow(8uL, "8ul", DisplayName = "UInt64")]
   [DataRow(9f, "9f", DisplayName = "Single")]
   [DataRow(10d, "10d", DisplayName = "Double")]
   [TestMethod]
   public void FormatArguments_WithKnownArgumentType_ReturnsExpectedArgument(object? value, string expectedArgument)
   {
      // Arrange
      object?[] arguments = [value];
      string[] expected = [expectedArgument];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }

   [TestMethod]
   public void FormatArguments_WithDecimal_ReturnsExpectedArgument()
   {
      // Arrange
      object?[] arguments = [1m];
      string[] expected = ["1m"];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }

#if NET5_0_OR_GREATER
   [TestMethod]
   public void FormatArguments_WithHalf_ReturnsExpectedArgument()
   {
      // Arrange
      object?[] arguments = [(System.Half)1];
      string[] expected = ["1h"];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }
#endif

   [DataRow("", "\"\"", DisplayName = "Empty string")]
   [DataRow("\0", "\"\\0\"", DisplayName = "Null character")]
   [DataRow("\r", "\"\\r\"", DisplayName = "Carriage return")]
   [DataRow("\n", "\"\\n\"", DisplayName = "Line feed")]
   [DataRow("\t", "\"\\t\"", DisplayName = "Tab")]
   [DataRow("\a", "\"\\a\"", DisplayName = "Bell")]
   [DataRow("\b", "\"\\b\"", DisplayName = "Backslash")]
   [DataRow("\f", "\"\\f\"", DisplayName = "Form feed")]
   [DataRow("\v", "\"\\v\"", DisplayName = "Vertical tab")]
   [DataRow("\u007f", "\"\\u007F\"", DisplayName = "Unicode 'control' character")]
   [DataRow("\u2028", "\"\\u2028\"", DisplayName = "Unicode 'line separator' character")]
   [DataRow("\u2029", "\"\\u2029\"", DisplayName = "Unicode 'paragraph separator' character")]
   [DataRow("\"", "\"\\\"\"", DisplayName = "Speech mark")]
   [DataRow("test", "\"test\"", DisplayName = "\"test\"")]
   [DataRow("test \n data", "\"test \\n data\"", DisplayName = "\"test \\n data\"")]
   [TestMethod]
   public void FormatArguments_WithString_ReturnsExpectedArgument(string value, string expectedArgument)
   {
      // Arrange
      object?[] arguments = [value];
      string[] expected = [expectedArgument];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }

   [DataRow(null, "<null>", DisplayName = "Null")]
   [DataRow("test", "test", DisplayName = "\"test\"")]
   [DataRow("test \n data", "test \\n data", DisplayName = "\"test \\n data\"")]
   [TestMethod]
   public void FormatArguments_WithUnknownType_ReturnsExpectedArgument(string? value, string expectedArgument)
   {
      // Arrange
      Stub stub = new(value);
      object?[] arguments = [stub];
      string[] expected = [expectedArgument];

      // Act
      string[] result = FormattingHelper.FormatArguments(arguments);

      // Assert
      CollectionAssert.AreEqual(expected, result);
   }
   #endregion
}
