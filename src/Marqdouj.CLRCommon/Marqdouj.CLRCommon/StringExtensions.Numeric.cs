namespace Marqdouj.CLRCommon
{
    public static partial class StringExtensions
    {
        #region Bool

        /// <summary>
        /// Converts Y/N, YES/NO, 1/-1 to bool or else uses bool.Parse methods.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return null; otherwise return value based on force parameter</returns>
        public static bool? ToBoolOrNull(this string value, bool force = true)
        {
            bool? nullBool = null;
            if (string.IsNullOrWhiteSpace(value)) return nullBool;

            var uValue = value.Trim().ToUpper();
            var yes = new List<string> { "Y", "YES", "1", "-1" };
            var no = new List<string> { "N", "NO", "0" };

            if (yes.Contains(uValue)) return true;
            if (no.Contains(uValue)) return false;

            if (force)
                return bool.Parse(value);

            return bool.TryParse(value, out var result) ? result : nullBool;
        }

        #endregion

        #region Decimal

        /// <summary>
        /// <see cref="decimal.TryParse(string, out decimal)"/> <see cref="decimal.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return default value; otherwise return value based on force parameter</returns>
        public static decimal ToDecimalOrValue(this string value, decimal defaultValue, bool force = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            if (force)
                return value.ToDecimal();

            return decimal.TryParse(value, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// <see cref="decimal.TryParse(string, out decimal)"/>, <see cref="decimal.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return null; otherwise return value based on force parameter</returns>
        public static decimal? ToDecimalOrNull(this string value, bool force = true)
        {
            decimal? nullDecimal = null;
            if (string.IsNullOrWhiteSpace(value))
                return nullDecimal;

            if (force)
                return value.ToDecimal();

            return decimal.TryParse(value, out var result) ? result : nullDecimal;
        }

        /// <summary>
        /// <see cref="decimal.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        #endregion

        #region Double

        /// <summary>
        /// <see cref="double.TryParse(string, out double)"/> <see cref="double.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return default value; otherwise return value based on force parameter</returns>
        public static double ToDoubleOrValue(this string value, double defaultValue, bool force = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            if (force)
                return value.ToDouble();

            return double.TryParse(value, out var result) ? result : defaultValue;
        }

        /// <summary>
        /// <see cref="double.TryParse(string, out double)"/>, <see cref="double.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return null; otherwise return value based on force parameter</returns>
        public static double? ToDoubleOrNull(this string value, bool force = true)
        {
            double? nullDouble = null;
            if (string.IsNullOrWhiteSpace(value))
                return nullDouble;

            if (force)
                return value.ToDouble();

            return double.TryParse(value, out var result) ? result : nullDouble;
        }

        /// <summary>
        /// <see cref="double.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        #endregion

        #region Int32

        /// <summary>
        /// <see cref="int.TryParse(string, out int)"/>, <see cref="int.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return default value; otherwise return value based on force parameter</returns>
        public static int ToInt32OrValue(this string value, int defaultValue, bool force = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            if (force)
                return value.ToInt32();

            return int.TryParse(value.ToAnyInt32String(), out var result) ? result : defaultValue;
        }

        /// <summary>
        /// <see cref="int.TryParse(string, out int)"/>, <see cref="int.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return null; otherwise return value based on force parameter</returns>
        public static int? ToInt32OrNull(this string value, bool force = true)
        {
            int? nullInt = null;
            if (string.IsNullOrWhiteSpace(value))
                return nullInt;

            if (force)
                return value.ToInt32();

            return int.TryParse(value.ToAnyInt32String(), out var result) ? result : nullInt;
        }

        /// <summary>
        /// <see cref="int.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(this string value)
        {
            return int.Parse(value.ToAnyInt32String());
        }


        /// <summary>
        /// int.Parse will not accept a string like '3.000' - it must be '3'.
        /// To work around this try to convert to double and back.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ToAnyInt32String(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            if (double.TryParse(value, out var dblValue))
                return Convert.ToInt32(dblValue).ToString();

            return value;
        }

        #endregion

        #region Int64

        /// <summary>
        /// <see cref="long.TryParse(string, out long)"/>, <see cref="long.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return default value; otherwise return value based on force parameter</returns>
        public static long ToInt64OrValue(this string value, int defaultValue, bool force = true)
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            if (force)
                return value.ToInt64();

            return long.TryParse(value.ToAnyInt64String(), out var result) ? result : defaultValue;
        }

        /// <summary>
        /// <see cref="long.TryParse(string?, out long)"/>, <see cref="long.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="force">If true then use Parse; otherwise use TryParse</param>
        /// <returns>If value is null or whitespace then return null; otherwise return value based on force parameter</returns>
        public static long? ToInt64OrNull(this string value, bool force = true)
        {
            long? nullLong = null;
            if (string.IsNullOrWhiteSpace(value))
                return nullLong;

            if (force)
                return value.ToInt64();

            return long.TryParse(value.ToAnyInt64String(), out var result) ? result : nullLong;
        }

        /// <summary>
        /// <see cref="long.Parse(string)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(this string value)
        {
            return long.Parse(value.ToAnyInt64String());
        }


        /// <summary>
        /// long.Parse will not accept a string like '3.000' - it must be '3'.
        /// To work around this try to convert to double and back.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ToAnyInt64String(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            if (double.TryParse(value, out var dblValue))
                return Convert.ToInt64(dblValue).ToString();

            return value;
        }

        #endregion

        /// <summary>
        /// Determines whether or not a string is numeric
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <returns>
        /// True if the string is numeric
        /// False if the string is not numeric (or empty)
        /// </returns>
        public static bool IsNumeric(this string value)
        {
            return double.TryParse(value, out _);
        }

        /// <summary>
        /// Determines whether or not a string is a positive integer
        /// </summary>
        /// <param name="value">The string to parse</param>
        /// <returns>
        /// True if the string is numeric
        /// False if the string is not numeric (or empty)
        /// </returns>
        public static bool IsPositiveInteger(this string value)
        {
            return long.TryParse(value, out var result) && result > 0;
        }
    }
}
