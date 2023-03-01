using MyCRM.Filters;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class TaskService
    {
        IRepositoryManager _repository;
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
                PaginationFilter = new PaginationFilter(_repository.Tasks.CountByFilter(taskFilter), taskFilter.Page),
                TaskFilter = taskFilter
            };
            viewModel.Tasks = _repository.Tasks.GetTasksByFilter(taskFilter, viewModel.PaginationFilter);
            return viewModel;
        }

        public void Create(TaskViewModel model, string creatorId)
        {
            model.Task.Author = _repository.Users.GetById(creatorId);
            model.Task.Executor = _repository.Users.GetById(model.executorId);
            model.Task.Project = _repository.Projects.GetById(model.projectId);
            model.Task.CreatedDate = DateTime.Now;
            model.Task.Status = Models.TaskStatus.New;
            _repository.Tasks.Create(model.Task);
            _repository.Save();
        }

        public Tasks GetById(int id)
        {
            return _repository.Tasks.GetById(id);
        }

        public TaskViewModel GetAddView(int id)
        {
            var viewModel = new TaskViewModel()
            {
                AllUsers = _repository.Users.GetAll(),
                AllProjects = _repository.Projects.GetAllWithoutPagination()
            };
            return viewModel;
        }

        public void Update(TaskViewModel model)
        {
            model.Task.Author = _repository.Users.GetById(model.creatorId);
            model.Task.Executor = _repository.Users.GetById(model.executorId);
            model.Task.Project = _repository.Projects.GetById(model.projectId);
            _repository.Tasks.Update(model.Task);
            _repository.Save();
        }
    }
}
