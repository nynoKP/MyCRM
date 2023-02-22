using MyCRM.Data;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext context) => this.context = context;

        public List<CRMUser> GetAll()
        {
            return context.Users.ToList();
        }

        public CRMUser GetById(string Id)
        {
            return context.Users.Where(c=>c.Id == Id).First();
        }
        public void Save() => context.SaveChanges();
    }
}
