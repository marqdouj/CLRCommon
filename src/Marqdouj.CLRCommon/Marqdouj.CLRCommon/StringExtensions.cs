using System.Globalization;

namespace Marqdouj.CLRCommon
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="suffix">value to append if string is truncated. default = …</param>
        /// <returns></returns>
        public static string? Truncate(this string value, int maxLength, string suffix = "…")
        {
            return value?.Length > maxLength
                ? $"{value[..maxLength]}{suffix}"
                : value;
        }

        /// <summary>
        /// Converts a string to title case using the specified culture.
        /// <see cref="TextInfo.ToTitleCase(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="culture"><see cref="CultureInfo.Name"/></param>
        /// <param name="useUserOverride"><see cref="CultureInfo.UseUserOverride"/></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value, string culture = "en-US", bool useUserOverride = false)
        {
            var ti = new CultureInfo(culture, useUserOverride).TextInfo;
            return ti.ToTitleCase(value);
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <remarks>
        /// Mimics Visual Basic's Left function
        /// </remarks>
        /// <param name="value">The string from which the leftmost characters are returned.</param>
        /// <param name="length">The number of characters to return. If greater than or equal to the number of characters in string, the entire string is returned.</param>        
        public static string? Left(this string value, int length)
        {
            return value == null || length > value.Length ? value : value[..length];
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <remarks>
        /// Mimics Visual Basic's Right function
        /// </remarks>
        /// <param name="value">The string from which the rightmost characters are returned.</param>
        /// <param name="length">The number of characters to return. If greater than or equal to the number of characters in string, the entire string is returned.</param>        
        public static string? Right(this string value, int length)
        {
            return value == null || length > value.Length ? value : value.Substring(value.Length - length, length);
        }

        /// <summary>
        /// Takes a string and converts its line endings to CrLf
        /// </summary>
        /// <remarks>
        /// Normally used with WebServices as sometimes you will get \n instead of \r\n when sending strings back and forth. 
        /// </remarks>
        /// <param name="value">The string to convert line endings</param>
        /// <returns>The reformatted string</returns>
        public static string ToCrLf(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            value = value.Replace("\r\n", "\n");
            value = value.Replace("\r", "\n");
            value = value.Replace("\n", "\r\n");

            return value;
        }
    }
}
