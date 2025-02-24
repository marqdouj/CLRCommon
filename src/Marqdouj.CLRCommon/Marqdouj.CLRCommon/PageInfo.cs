namespace Marqdouj.CLRCommon
{
    /// <summary>
    /// Normally this class would be used as a property of a filter class.
    /// A separate property keeps the paging organized as to not interfere with the actual filter properties.
    /// </summary>
    /// <![CDATA[
    /// public class MyFilter
    /// {
    ///      public PageInfo PageInfo { get; set; } = new PageInfo();
    ///    
    ///      public int? Id { get; set; }
    ///      public string SearchName { get; set; }
    ///      //etc... 
    /// }
    /// ]]>
    public class PageInfo
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; }
    }
}
