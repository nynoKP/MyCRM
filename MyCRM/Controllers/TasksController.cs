using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Repository;
using MyCRM.ViewModels;

namespace MyCRM.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly TaskRepository _taskRepository;
        private readonly ProjectRepository _projectRepository;
        private readonly ContragentRepository _contragentRepository;

        public TasksController(ApplicationDbContext context)
        {
            _userRepository = new UserRepository(context);
            _taskRepository = new TaskRepository(context);
            _projectRepository = new ProjectRepository(context);
            _contragentRepository = new ContragentRepository(context);
        }

        public IActionResult Index([FromForm] TaskFilter? taskFilter = null)
        {
            if (taskFilter == null) taskFilter = new TaskFilter();
            var viewModel = new TaskViewModel()
            {
                AllUsers = _userRepository.GetAll(),
                AllContragents = _contragentRepository.GetAllWithoutPagination(),
                AllProjects = _projectRepository.GetAllWithoutPagination(),
                PaginationFilter = new PaginationFilter(_taskRepository.CountByFilter(taskFilter), taskFilter.Page),
                TaskFilter = taskFilter
            };
            viewModel.Tasks = _taskRepository.GetTasksByFilter(taskFilter, viewModel.PaginationFilter);
            return View(viewModel);
        }

        public IActionResult CreateTaskForm()
        {
            return View(_userRepository.GetAll());
        }

        public IActionResult Create([FromForm] PaginationFilter filter, string executorId)
        {
            return View();
        }
    }
}
