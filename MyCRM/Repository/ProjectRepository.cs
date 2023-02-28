using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class ProjectRepository : RepositoryBase<Project>
    {
        public ProjectRepository(ApplicationDbContext context) : base(context) => this.context = context;

        public List<Project> GetAll(PaginationFilter filter)
        {
            return FindAll()
                .Skip((filter.page - 1) * filter.pageSize)
                .Take(filter.pageSize)
                .ToList();
        }

        public List<Project> GetAllWithoutPagination()
        {
            return FindAll()
                .ToList();
        }

        public Project GetById(int id)
        {
            return FindByCondition(c => c.Id == id)
                .First();
        }
    }
}
