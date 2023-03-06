using MyCRM.Data;
using MyCRM.Models;

namespace MyCRM.Repository
{
    public class TaskStateRepository : RepositoryBase<TaskState>
    {
        public TaskStateRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public TaskState GetDefault()
        {
            var defaultStatus = FindByCondition(c => c.isDefault == true).FirstOrDefault();
            if(defaultStatus == null)
            {
                defaultStatus = FindAll().First();
                defaultStatus.isDefault = true;
                Update(defaultStatus);
            }
            return defaultStatus;
        }

        public void SetDefault(TaskState value)
        {
            var nowDefault = FindByCondition(c => c.isDefault == true).ToList();
            foreach (var item in nowDefault)
            {
                item.isDefault = false;
                Update(item);
            }
            value.isDefault = true;
            Update(value);
        }

        public TaskState GetById(int id)
        {
            return FindByCondition(c => c.Id == id).First();
        }
    }
}
