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

        public News GetById(int Id)
        {
            return context.News.Include(c=>c.Author)
                .First(c => c.Id == Id);
        }

        public List<News> GetByCreator(string AuthorId)
        {
            return context.News.Include(c=>c.Author)
                .Where(c=>c.Author.Id == AuthorId)
                .OrderByDescending(c=>c.CreatedDate)
                .ToList();
        }
        public List<News> GetAll(PaginationFilter filter)
        {
            return context.News.Include(c => c.Author)
                .OrderByDescending(c => c.CreatedDate)
                .ToList()
                .Where((e, i) => i >= (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page)
                .ToList();
        }

        public void Add(News crmNews) => context.News.Add(crmNews);

        public int Count()
        {
            return context.News.Count();
        }

        public void Update(News crmNews)
        {
            context.News.Update(crmNews);
        }

        public void Save() => context.SaveChanges();
    }
}
