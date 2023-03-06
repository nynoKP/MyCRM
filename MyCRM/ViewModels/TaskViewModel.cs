using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class TaskViewModel
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public IEnumerable<CRMUser> AllUsers { get; set; }
        public IEnumerable<Project> AllProjects { get; set; }
        public IEnumerable<Contragent> AllContragents { get; set; }
        public IEnumerable<TaskState> TaskStatuses { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
        public TaskFilter TaskFilter { get; set; }
        public Tasks Task { get; set; }
    }
}
