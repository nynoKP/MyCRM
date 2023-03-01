namespace MyCRM.Filters
{
    public class TaskFilter
    {
        private int page;
        public string? UserId { get; set; }
        public int? ProjectId { get; set; }
        public int? ContractorId { get; set; }
        public int Page { get { return page == 0 ? 1 : page; } set { page = value; } }
    }
}
