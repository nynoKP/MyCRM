using MyCRM.Data;

namespace MyCRM.Repository
{
    public class TaskRepository
    {
        private readonly ApplicationDbContext context;
        public TaskRepository(ApplicationDbContext context) => this.context = context;

        
    }
}
