using System.Globalization;
using System.Text;

namespace OwlDomain.Testing;

/// <summary>
/// A helper class for formatting output arguments.
/// </summary>
public static class FormattingHelper
{
   #region Functions
   /// <summary>Formats the given <paramref name="arguments"/> to ensure that they are readable in the output.</summary>
   /// <param name="arguments">The arguments to format.</param>
   /// <returns>The formatted arguments.</returns>
   public static string[] FormatArguments(params object?[] arguments)
   {
      StringBuilder builder = new StringBuilder();

      string[] newArgs = new string[arguments.Length];
      for (int i = 0; i < arguments.Length; i++)
      {
         object? obj = arguments[i];
         string newArg = FormatArgument(obj, builder);
         newArgs[i] = newArg;
      }

      return newArgs;
   }

   #endregion

   #region Helpers
   private static string FormatArgument(object? argument, StringBuilder builder)
   {
      if (TryTypeReplacement(argument, out string? typeReplacement))
         return typeReplacement;

      string? str = argument.ToString();
      if (str is null)
         return "<null>";

      ReadOnlySpan<char> span = str;

      builder.EnsureCapacity(str.Length);

      int lastAppend = 0;
      for (int i = 0; i < str.Length; i++)
      {
         char ch = str[i];
         if (TryReplace(ch, out string? replacement))
         {
            if (i > lastAppend)
               builder.Append(span[lastAppend..i]);

            lastAppend = i + 1;
            builder.Append(replacement);
         }
      }

      builder.Append(span[lastAppend..]);

      str = builder.ToString();
      builder.Clear();

      return str;
   }

   private static bool TryTypeReplacement([NotNullWhen(false)] object? argument, [NotNullWhen(true)] out string? replacement)
   {
      replacement = argument switch
      {
         null => "<null>",

         string value => EscapeString(value),
         bool value => value ? "true" : "false",
         char value => $"'{value}'",

         sbyte value => $"{value}sb",
         byte value => $"{value}b",
         short value => $"{value}s",
         ushort value => $"{value}us",

         int value => $"{value}",
         uint value => $"{value}u",

         long value => $"{value}l",
         ulong value => $"{value}ul",
         float value => $"{value}f",
         double value => $"{value}d",
         decimal value => $"{value}m",

#if NET5_0_OR_GREATER
         Half value => $"{value}h",
#endif

         _ => null
      };

      return replacement is not null;
   }
   private static bool TryReplace(char value, [NotNullWhen(true)] out string? replacement)
   {
      replacement = value switch
      {
         '\0' => "\\0",
         '\r' => "\\r",
         '\n' => "\\n",
         '\t' => "\\t",
         '\a' => "\\a",
         '\b' => "\\b",
         '\f' => "\\f",
         '\v' => "\\v",

         _ => null
      };

      if (replacement is not null)
         return true;

      UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(value);
      if (ShouldEscape(category))
      {
         int numerical = value;
         replacement = $"\\u{numerical:X4}";
      }

      return replacement is not null;
   }
   private static string EscapeString(string value)
   {
      StringBuilder builder = new StringBuilder(value.Length);
      builder.Append('"');

      ReadOnlySpan<char> span = value;

      int lastAppend = 0;
      for (int i = 0; i < value.Length; i++)
      {
         char ch = value[i];

         string? replacement;

         if (ch == '"')
            replacement = "\\\"";
         else
            TryReplace(ch, out replacement);

         if (replacement is not null)
         {
            if (i > lastAppend)
               builder.Append(span[lastAppend..i]);

            lastAppend = i + 1;
            builder.Append(replacement);
         }
      }

      builder.Append(span[lastAppend..]);
      builder.Append('"');

      string result = builder.ToString();
      builder.Clear();

      return result;
   }
   private static bool ShouldEscape(UnicodeCategory category)
   {
      return category switch
      {
         UnicodeCategory.Control => true,
         UnicodeCategory.ParagraphSeparator => true,
         UnicodeCategory.LineSeparator => true,

         _ => false
      };
   }
   #endregion
}
