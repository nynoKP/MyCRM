namespace MyCRM.Filters
{
    public class PaginationFilter
    {
        private int Page = 1;
        public int pageSize = 10;
        public int total = 0;

        public PaginationFilter() { }
        public PaginationFilter(int total, int page = 1, int pageSize = 10)
        {
            this.Page = page;
            this.total = total;
            this.pageSize = pageSize;
        }

        public int page { get { return Page < 1 ? 1 : Page; } set { Page = value; } }

        public int PageCount => (int)Math.Ceiling((decimal)total / pageSize);

        public bool HasValues() => total != 0;
    }
}
