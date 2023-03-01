using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class ProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public PaginationFilter PaginationFilter { get; set; }
    }
}
