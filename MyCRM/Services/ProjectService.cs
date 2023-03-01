using Castle.Core.Resource;
using MyCRM.Filters;
using MyCRM.Interface.Repository;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Services
{
    public class ProjectService
    {
        private readonly IRepositoryManager _repository;
        public ProjectService(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }

        public ProjectViewModel GetIndexView(int page)
        {
            var filter = new PaginationFilter(_repository.Projects.Count(), page);
            var viewModel = new ProjectViewModel()
            {
                PaginationFilter = filter,
                Projects = _repository.Projects.GetAll(filter)
            };
            return viewModel;
        }

        public ProjectCreateViewModel GetAddView()
        {
            var viewModel = new ProjectCreateViewModel()
            {
                Contragents = _repository.Contragent.GetAllWithoutPagination(),
                Users = _repository.Users.GetAll()
            };
            return viewModel;
        }

        public Project GetById(int id)
        {
            return _repository.Projects.GetById(id);
        }

        public ProjectCreateViewModel GetEditView(int projectId)
        {
            var viewModel = new ProjectCreateViewModel()
            {
                Contragents = _repository.Contragent.GetAllWithoutPagination(),
                Users = _repository.Users.GetAll(),
                EditProject = GetById(projectId)
            };
            return viewModel;
        }

        public void Update(Project project)
        {
            project.Creator = _repository.Users.GetById(project.Creator.Id);
            project.Responsible = _repository.Users.GetById(project.Responsible.Id);
            project.Customer = _repository.Contragent.GetById(project.Customer.Id);
            _repository.Projects.Update(project);
            _repository.Save();
        }

        public void Create(Project project, string creatorId)
        {
            project.Creator = _repository.Users.GetById(creatorId);
            project.Responsible = _repository.Users.GetById(project.Responsible.Id);
            project.Customer = _repository.Contragent.GetById(project.Customer.Id);
            _repository.Projects.Create(project);
            _repository.Save();
        }
    }
}
