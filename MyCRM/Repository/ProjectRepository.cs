using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class ProjectRepository
    {
        private readonly ApplicationDbContext context;
        public ProjectRepository(ApplicationDbContext context) => this.context = context;

        public List<Project> GetAll(PaginationFilter filter)
        {
            return context.Projects.Include(c => c.Customer)
                .Include(c => c.Creator)
                .Include(c => c.Responsible)
                .ToList()
                .Where((e, i) => i >= (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page)
                .ToList();
        }

        public List<Project> GetAllWithoutPagination()
        {
            return context.Projects.Include(c => c.Customer)
                .Include(c => c.Creator)
                .Include(c => c.Responsible)
                .ToList();
        }

        public Project GetById(int id)
        {
            return context.Projects.Include(c => c.Customer)
                .Include(c => c.Creator)
                .Include(c => c.Responsible)
                .Where(c => c.Id == id).First();
        }

        public int Count() => context.Projects.Count();

        public void Add(Project contragent)
        {
            context.Projects.Add(contragent);
        }

        public void Update(Project contragent)
        {
            context.Projects.Update(contragent);
        }
        public void Save() => context.SaveChanges();
    }
}
