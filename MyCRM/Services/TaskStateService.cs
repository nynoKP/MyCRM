using MyCRM.Interface.Repository;
using MyCRM.Models;

namespace MyCRM.Services
{
    public class TaskStateService
    {
        private IRepositoryManager _repository;

        public TaskStateService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public IEnumerable<TaskState> GetAll()
        {
            return _repository.TaskStatuses.FindAll().ToList();
        }

        public TaskState Get(int id)
        {
            return _repository.TaskStatuses.FindByCondition(c => c.Id == id)
                .First();
        }

        public void Update(TaskState status)
        {
            _repository.TaskStatuses.Update(status);
            _repository.Save();
        }

        public void Delete(TaskState status)
        {
            _repository.TaskStatuses.Delete(status);
            _repository.Save();
        }

        public void Create(TaskState status)
        {
            _repository.TaskStatuses.Create(status);
            _repository.Save();
        }

        public TaskState GetDefault()
        {
            return _repository.TaskStatuses.GetDefault();
        }

        public void UpdateDefault(TaskState status)
        {
            _repository.TaskStatuses.Update(status);
            _repository.Save();
        }
    }
}
