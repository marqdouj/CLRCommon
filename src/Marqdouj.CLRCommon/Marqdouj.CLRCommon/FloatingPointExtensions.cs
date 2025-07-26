namespace Marqdouj.CLRCommon
{
    public static class FloatingPointExtensions
    {
        /// <summary>
        /// Formats a decimal to a string using the specified format.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"><see cref="decimal.ToString(string?)"></param>
        /// <param name="truncateZeros">remove decimal places if they are all zeros (i.e. 1.00 becomes 1)</param>
        /// <param name="truncateFormat">format used when truncating></param>"
        /// <returns></returns>
        public static string ToStringFormat(this decimal value, string format = "N2", bool truncateZeros = false, string truncateFormat = "N0")
        {
            return value.ToString(format).TruncateZeros(truncateZeros, truncateFormat);
        }

        /// <summary>
        /// Formats a double to a string using the specified format.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"><see cref="double.ToString(string?)"></param>
        /// <param name="truncateZeros">remove decimal places if they are all zeros (i.e. 1.00 becomes 1)</param>
        /// <param name="truncateFormat">format used when truncating></param>"
        /// <returns></returns>
        public static string ToStringFormat(this double value, string format = "N2", bool truncateZeros = false, string truncateFormat = "N0")
        {
            return value.ToString(format).TruncateZeros(truncateZeros, truncateFormat);
        }

        /// <summary>
        /// Formats a float to a string using the specified format.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"><see cref="float.ToString(string?)"></param>
        /// <param name="truncateZeros">remove decimal places if they are all zeros (i.e. 1.00 becomes 1)</param>
        /// <param name="truncateFormat">format used when truncating></param>"
        /// <returns></returns>
        public static string ToStringFormat(this float value, string format = "N2", bool truncateZeros = false, string truncateFormat = "N0")
        {
            return value.ToString(format).TruncateZeros(truncateZeros, truncateFormat);
        }

        private static string TruncateZeros(this string value, bool truncateZeros, string truncateFormat)
        {
            // If formatted decimal places are all zeros (i.e. 1.00) and truncate zeros is true,
            // then reformat to F0
            if (truncateZeros)
            {
                // Decimal is used because it can handle decimal, double, and float values
                if (decimal.TryParse(value, out var parsedValue) && parsedValue == Math.Truncate(parsedValue))
                    value = parsedValue.ToString(truncateFormat);
            }

            return value;
        }
    }
}
