using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class TaskRepository
    {
        private readonly ApplicationDbContext context;
        public TaskRepository(ApplicationDbContext context) => this.context = context;

        public int CountByFilter(TaskFilter taskFilter)
        {
            var all = context.Tasks.Include(c => c.Executor)
                .Include(c => c.Author)
                .Include(c => c.Project)
                .ThenInclude(c => c.Customer).ToList();
            if (taskFilter.ContractorId != null)
            {
                all = all.Where(c=>c.Project.Customer.Id == taskFilter.ContractorId).ToList();
            }
            if (taskFilter.ProjectId != null)
            {
                all = all.Where(c => c.Project.Id == taskFilter.ProjectId).ToList();
            }
            if (taskFilter.UserId != null)
            {
                all = all.Where(c => c.Executor.Id == taskFilter.UserId).ToList();
            }
            return all.Count;
        }

        public IEnumerable<Tasks> GetTasksByFilter(TaskFilter taskFilter, PaginationFilter paginationFilter)
        {
            var all = context.Tasks.Include(c => c.Executor)
                .Include(c => c.Author)
                .Include(c => c.Project)
                .ThenInclude(c => c.Customer).ToList();
            if (taskFilter.ContractorId != null)
            {
                all = all.Where(c => c.Project.Customer.Id == taskFilter.ContractorId).ToList();
            }
            if (taskFilter.ProjectId != null)
            {
                all = all.Where(c => c.Project.Id == taskFilter.ProjectId).ToList();
            }
            if (taskFilter.UserId != null)
            {
                all = all.Where(c => c.Executor.Id == taskFilter.UserId).ToList();
            }
            all = all.Where((e, i) => i >= (paginationFilter.page - 1) * paginationFilter.pageSize && i < paginationFilter.pageSize * paginationFilter.page)
                .ToList();
            return all;
        }

        public void Save() => context.SaveChanges();
    }
}
