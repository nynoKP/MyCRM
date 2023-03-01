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
        public PaginationFilter PaginationFilter { get; set; }
        public TaskFilter TaskFilter { get; set; }
        public Tasks Task { get; set; }
        public string creatorId { get; set; }
        public string executorId { get; set; }
        public int projectId { get; set; }
    }
}
