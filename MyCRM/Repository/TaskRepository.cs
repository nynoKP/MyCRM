using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class TaskRepository : RepositoryBase<Tasks>
    {
        public TaskRepository(ApplicationDbContext context) : base(context) => this.context = context;

        public int CountByFilter(TaskFilter taskFilter)
        {
            var all = FindAll().ToList();
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
            if (taskFilter.StatusId != null)
            {
                all = all.Where(c => c.Status.Id == taskFilter.StatusId).ToList();
            }
            return all.Count;
        }

        public IEnumerable<Tasks> GetTasksByFilter(TaskFilter taskFilter, PaginationFilter filter)
        {
            var all = FindAll().ToList();
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
            if (taskFilter.StatusId != null)
            {
                all = all.Where(c => c.Status.Id == taskFilter.StatusId).ToList();
            }
            all = all.Skip((filter.page - 1) * filter.pageSize)
                .Take(filter.pageSize)
                .ToList();
            return all;
        }

        public Tasks GetById(int id)
        {
            return FindByCondition(c => c.Id == id).First();
        }
    }
}
