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
            return _repository.TaskStatuses.FindAll().OrderBy(c=>c.Id).ToList();
        }

        public TaskState Get(int id)
        {
            return _repository.TaskStatuses.FindByCondition(c => c.Id == id)
                .First();
        }

        public void Update(TaskState status)
        {
            if (status.isDefault)
            {
                UpdateDefault(status);
            }
            else
            {
                _repository.TaskStatuses.Update(status);
                _repository.Save();
            }
        }

        public void Delete(int id)
        {
            var status = _repository.TaskStatuses.FindByCondition(c=>c.Id == id).First();
            _repository.TaskStatuses.Delete(status);
            _repository.Save();
        }

        public void Create(TaskState status)
        {
            if (status.isDefault)
            {
                UpdateDefault(status);
            }
            else
            {
                _repository.TaskStatuses.Create(status);
                _repository.Save();
            }
        }

        public TaskState GetDefault()
        {
            return _repository.TaskStatuses.GetDefault();
        }

        public void UpdateDefault(TaskState status)
        {
            _repository.TaskStatuses.SetDefault(status);
            _repository.Save();
        }

        public ResultAction TryDelete(int id)
        {
            var tasks = _repository.Tasks.FindByCondition(c => c.Status.Id == id);
            if(tasks.Count() > 0)
            {
                return new ResultAction() { Success = false, Message = "Нельзя удалить используемый статус. Сначала определите задачи в другой!" };
            }
            else
            {
                Delete(id);
                return new ResultAction() { Success = false};
            }
        }
    }
}
