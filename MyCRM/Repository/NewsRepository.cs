using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class NewsRepository : RepositoryBase<News>
    {
        public NewsRepository(ApplicationDbContext context) : base(context) => this.context = context;

        public News GetById(int Id)
        {
            return FindByCondition(c=>c.Id == Id)
                .First();
        }

        public List<News> GetAll(PaginationFilter filter)
        {
            return FindAll()
                .OrderByDescending(c => c.CreatedDate)
                .Skip((filter.page - 1) * filter.pageSize)
                .Take(filter.pageSize)
                .ToList();
        }
    }
}
