using System.Collections.ObjectModel;

namespace Marqdouj.CLRCommon
{
    /// <summary>
    /// Manages a list of Enum (no duplicates).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumList<T> where T : Enum
    {
        private readonly List<T> items = [];

        public EnumList() 
        { Items = new ReadOnlyCollection<T>(items); }

        public EnumList(IEnumerable<T> values) 
            :this() 
        { AddValues(values); }

        public int Count => Items.Count;
        public IReadOnlyCollection<T> Items { get; }

        public void AddValue(T item)
        {
            if (item == null)
                return;

            if (!items.Contains(item))
                items.Add(item);
        }

        public void AddValues(IEnumerable<T> values)
        {
            if (values == null)
                return;

            foreach (var item in values)
            {
                AddValue(item);
            }
        }

        public void AddValues(params T[] values)
        {
            foreach (var item in values)
            {
                AddValue(item);
            }
        }

        public bool RemoveItem(T value) => items.Remove(value);

        public void RemoveItems(IEnumerable<T> values)
        {
            foreach (var item in values)
            {
                RemoveItem(item);
            }
        }

        public void RemoveItems(params T[] values)
        {
            foreach (var item in values)
            {
                RemoveItem(item);
            }
        }

        /// <summary>
        /// Get the list of names of the items
        /// </summary>
        /// <returns>Ordered list of item names (.ToString())</returns>
        public List<string> ToNames() => [.. items.Select(e => e.ToString()).OrderBy(e => e)];
    }
}
