using MyCRM.Data;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class UserRepository : RepositoryBase<CRMUser>
    {
        public UserRepository(ApplicationDbContext context) : base(context) => this.context = context;

        public List<CRMUser> GetAll()
        {
            return FindAll().ToList();
        }

        public CRMUser GetById(string Id)
        {
            return FindByCondition(c=>c.Id == Id).First();
        }
    }
}
