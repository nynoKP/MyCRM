namespace MyCRM.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public CRMUser Author { get; set; }
        public CRMUser Executor { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        New,
        Active,
        Success,
        Overdue
    }
}
