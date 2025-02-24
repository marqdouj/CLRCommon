namespace Marqdouj.CLRCommon
{
    public class PagedRange : ICloneable
    {
        public PagedRange(int rowCount, int page, int pageSize)
        {
            if (rowCount <= 0)
            {
                Page = 1;
                PrevPage = 1;
                NextPage = 1;
                LastPage = 1;
                RowCount = 0;
                PageSize = 0;
                return;
            }

            if (pageSize <= 0)
                pageSize = 10;

            LastPage = (int)Math.Ceiling(decimal.Divide(rowCount, pageSize));

            if (page <= 0)
                page = 1;
            if (page > LastPage)
                page = LastPage;

            Page = page;
            RowCount = rowCount;
            PageSize = pageSize;

            const int firstPage = 1;
            PrevPage = Math.Max(page - 1, firstPage);
            NextPage = Math.Min(page + 1, LastPage);
        }

        public int RowCount { get; }
        public int Page { get; }
        public int PageSize { get; }

        public int PrevPage { get; }
        public int NextPage { get; }
        public int LastPage { get; }

        public long GetFirstRow()
        {
            if (RowCount <= 0) return 0;
            var row = (Page - 1) * PageSize + 1;
            if (row < 1) row = 1;
            return row;
        }

        public long GetLastRow()
        {
            if (RowCount <= 0) return 0;
            var row = GetFirstRow() + PageSize - 1;
            if (row > RowCount) row = RowCount;
            return row;
        }

        public List<int> GetPageIndexes()
        {
            var items = new List<int>();
            var firstIdx = Page - 3;

            if (firstIdx < 1)
                firstIdx = 1;

            var lastIdx = firstIdx + 4;
            if (lastIdx > LastPage)
                lastIdx = LastPage;

            while (lastIdx - firstIdx < 4 && firstIdx > 1)
            {
                firstIdx--;
            }

            for (var i = firstIdx; i <= lastIdx; i++)
            {
                items.Add(i);
            }

            return [.. items.OrderBy(e => e)];
        }

        public object Clone() => MemberwiseClone();
    }
}
