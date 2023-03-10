namespace MyCRM.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Deadline { get; set; }
        public virtual CRMUser Author { get; set; }
        public virtual CRMUser Executor { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskState Status { get; set; }
    }
}