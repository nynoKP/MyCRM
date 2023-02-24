using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class ContragentRepository
    {
        private readonly ApplicationDbContext context;
        public ContragentRepository(ApplicationDbContext context) => this.context = context;

        public List<Contragent> GetAll(PaginationFilter filter)
        {
            return context.Contragent.Include(c=>c.Creator)
                .ToList()
                .Where((e, i) => i >= (filter.page - 1) * filter.pageSize && i < filter.pageSize * filter.page)
                .ToList();
        }
        public List<Contragent> GetAllWithoutPagination()
        {
            return context.Contragent.Include(c => c.Creator)
                .ToList();
        }
        public Contragent GetById(int id)
        {
            return context.Contragent.Include(c => c.Creator)
                .Where(c=>c.Id == id)
                .First();
        }

        public int Count() => context.Contragent.Count();

        public void Add(Contragent contragent)
        {
            context.Contragent.Add(contragent);
        }

        public void Update(Contragent contragent)
        {
            context.Contragent.Update(contragent);
        }
        public void Save() => context.SaveChanges();
    }
}
