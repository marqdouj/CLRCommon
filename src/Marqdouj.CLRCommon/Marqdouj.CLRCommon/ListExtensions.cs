using System.Data;
using System.Reflection;

namespace Marqdouj.CLRCommon
{
    public static class ListExtensions
    {
        /// <summary>
        /// Converts a list of objects to a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="name"></param>
        /// <param name="exclusions"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> items, string? name = null, List<string>? exclusions = null) where T : class
        {
            exclusions ??= [];
            name ??= typeof(T).Name;
            var table = new DataTable(name);
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(e => !exclusions.Contains(e.Name)).ToList();

            foreach (var prop in props)
            {
                var type = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ?
                    Nullable.GetUnderlyingType(prop.PropertyType) :
                    prop.PropertyType;

                if (type != null)
                    table.Columns.Add(prop.Name, type);
            }

            foreach (var item in items)
            {
                var row = table.NewRow();

                foreach (var prop in props)
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
