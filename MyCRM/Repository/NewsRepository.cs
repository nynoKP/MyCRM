using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class NewsRepository
    {
        private readonly ApplicationDbContext context;
        public NewsRepository(ApplicationDbContext context) => this.context = context;

        public CRMNews GetById(int Id)
        {
            return context.News.First(c => c.Id == Id);
        }

        public List<CRMNews> GetByCreator(string AuthorId)
        {
            return context.News.Include(c=>c.Author)
                .Where(c=>c.Author.Id == AuthorId)
                .OrderByDescending(c=>c.CreatedDate)
                .ToList();
        }
        public List<CRMNews> GetAll(PaginationFilter filter)
        {
            return context.News.Include(c => c.Author)
                .OrderByDescending(c => c.CreatedDate)
                .ToList()
                .Where((e, i) => i >= (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page)
                .ToList();
        }

        public void Add(CRMNews crmNews) => context.News.Add(crmNews);

        public int Count()
        {
            return context.News.Count();
        }

        public void Save() => context.SaveChanges();
    }
}
