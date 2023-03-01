namespace MyCRM.Filters
{
    public class PaginationFilter
    {
        public int page = 1;
        public int pageSize = 10;
        public int total = 0;

        public PaginationFilter() { }
        public PaginationFilter(int total, int page = 1, int pageSize = 10)
        {
            this.page = page;
            this.total = total;
            this.pageSize = pageSize;
        }

        public int PageCount => (int)Math.Ceiling((decimal)total / pageSize);

        public bool HasValues() => total != 0;
    }
}
