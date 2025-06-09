namespace Marqdouj.CLRCommon
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Converts delimited string of integer to Int32 List
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<int> ToInt32List(this string value, char separator = ',')
        {
            var items = new List<int>();
            if (string.IsNullOrWhiteSpace(value)) return items;

            var sep = new char[] { separator };
            var values = value.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            foreach ( var item in values )
            {
                items.Add(Convert.ToInt32(item));
            }

            return items;
        }

        /// <summary>
        /// Converts delimited string of long to Int64 List
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static List<long> ToInt64List(this string value, char separator = ',')
        {
            var items = new List<long>();
            if (string.IsNullOrWhiteSpace(value)) return items;

            var sep = new char[] { separator };
            var values = value.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in values)
            {
                items.Add(Convert.ToInt64(item));
            }

            return items;
        }
    }
}
