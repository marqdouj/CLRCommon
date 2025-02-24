namespace Marqdouj.CLRCommon
{
    public class PagedData<T>(PagedRange pagedRange, List<T> results) where T : class
    {
        public PagedRange PagedRange { get; } = pagedRange;
        public List<T> Results { get; } = results;
    }
}
