using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class ContragentRepository : RepositoryBase<Contragent>
    {
        public ContragentRepository(ApplicationDbContext context) : base(context) => this.context = context;

        public List<Contragent> GetAll(PaginationFilter filter)
        {
            return FindAll()
                .Skip((filter.page - 1) * filter.pageSize)
                .Take(filter.pageSize)
                .ToList();
        }
        public List<Contragent> GetAllWithoutPagination()
        {
            return FindAll()
                .ToList();
        }
        public Contragent GetById(int id)
        {
            return FindByCondition(c=>c.Id == id)
                .First();
        }
    }
}
