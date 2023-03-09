using MyCRM.Filters;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class TaskService
    {
        private readonly IRepositoryManager _repository;
        public TaskService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public TaskViewModel GetIndexView(TaskFilter? taskFilter)
        {
            taskFilter ??= new TaskFilter();
            var viewModel = new TaskViewModel()
            {
                AllUsers = _repository.Users.GetAll(),
                AllContragents = _repository.Contragent.GetAllWithoutPagination(),
                AllProjects = _repository.Projects.GetAllWithoutPagination(),
                TaskStatuses = _repository.TaskStatuses.FindAll().ToList(),
                PaginationFilter = new PaginationFilter(_repository.Tasks.CountByFilter(taskFilter), taskFilter.Page),
                TaskFilter = taskFilter
            };
            viewModel.Tasks = _repository.Tasks.GetTasksByFilter(taskFilter, viewModel.PaginationFilter);
            return viewModel;
        }

        public void Create(Tasks task, string creatorId)
        {
            task.Author = _repository.Users.GetById(creatorId);
            task.Executor = _repository.Users.GetById(task.Executor.Id);
            task.Project = _repository.Projects.GetById(task.Project.Id);
            task.CreatedDate = DateTime.Now;
            task.Status = _repository.TaskStatuses.GetDefault();
            _repository.Tasks.Create(task);
            _repository.Save();
        }

        public Tasks GetById(int id)
        {
            return _repository.Tasks.GetById(id);
        }

        public TaskViewModel GetAddView()
        {
            var viewModel = new TaskViewModel()
            {
                AllUsers = _repository.Users.GetAll(),
                AllProjects = _repository.Projects.GetAllWithoutPagination(),
                TaskStatuses = _repository.TaskStatuses.FindAll().ToList()
            };
            return viewModel;
        }

        public void Update(Tasks task)
        {
            task.Author = _repository.Users.GetById(task.Author.Id);
            task.Executor = _repository.Users.GetById(task.Executor.Id);
            task.Project = _repository.Projects.GetById(task.Project.Id);
            task.Status = _repository.TaskStatuses.GetById(task.Status.Id);
            _repository.Tasks.Update(task);
            _repository.Save();
        }

        public TaskViewModel GetEditViewModel(int id)
        {
            var viewModel = new TaskViewModel()
            {
                AllUsers = _repository.Users.GetAll(),
                AllProjects = _repository.Projects.GetAllWithoutPagination(),
                TaskStatuses = _repository.TaskStatuses.FindAll().ToList(),
                Task = _repository.Tasks.GetById(id)
            };
            return viewModel;
        }

        public void UpdateTaskStatus(UpdateTaskStatus? model)
        {
            if (model != null && model.TaskId != null && model.StatusId != null)
            {
                var task = _repository.Tasks.GetById(model.TaskId.Value);
                task.Status = _repository.TaskStatuses.FindByCondition(c => c.Id == model.StatusId).First();
                _repository.Tasks.Update(task);
                _repository.Save();
            }
        }
    }
}
