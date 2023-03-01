using Microsoft.AspNetCore.Identity;
using MyCRM.Interface.Repository;
using MyCRM.Interface.Service;
using MyCRM.Models;

namespace MyCRM.Services
{
    public class ServiceManager: IServiceManager
    {
        private readonly Lazy<ContragentService> _contragentService;
        private readonly Lazy<NewsService> _newsService;
        private readonly Lazy<ProjectService> _projectService;
        private readonly Lazy<TaskService> _taskService;
        private readonly Lazy<UserService> _userService;

        public ServiceManager(IRepositoryManager repositoryManager, UserManager<CRMUser> userManager)
        {
            _contragentService = new Lazy<ContragentService>(() => new ContragentService(repositoryManager));
            _newsService = new Lazy<NewsService>(() => new NewsService(repositoryManager));
            _projectService = new Lazy<ProjectService>(() => new ProjectService(repositoryManager));
            _taskService = new Lazy<TaskService>(() => new TaskService(repositoryManager));
            _userService = new Lazy<UserService>(() => new UserService(repositoryManager, userManager));
        }

        public ContragentService Contragent => _contragentService.Value;
        public NewsService News => _newsService.Value;
        public ProjectService Project => _projectService.Value;
        public TaskService Task => _taskService.Value;
        public UserService User => _userService.Value;
    }
}
