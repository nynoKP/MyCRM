using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Models;
using MyCRM.Repository;
using MyCRM.ViewModels;
using System.Security.Claims;

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

        public IActionResult Create([FromForm] TaskViewModel model)
        {
            model.Task.Author = _userRepository.GetById(GetUserId());
            model.Task.Executor = _userRepository.GetById(model.executorId);
            model.Task.Project = _projectRepository.GetById(model.projectId);
            model.Task.CreatedDate = DateTime.Now;
            model.Task.Status = Models.TaskStatus.New;
            _taskRepository.Add(model.Task);
            _taskRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Watch(int id)
        {
            var task = _taskRepository.GetById(id);
            return View(task);
        }


        public IActionResult Add(int id)
        {
            var viewModel = new TaskViewModel()
            {
                AllUsers = _userRepository.GetAll(),
                AllProjects = _projectRepository.GetAllWithoutPagination()
            };
            return View(viewModel);
        }

        public IActionResult Update([FromForm] TaskViewModel model)
        {
            model.Task.Author = _userRepository.GetById(model.creatorId);
            model.Task.Executor = _userRepository.GetById(model.executorId);
            model.Task.Project = _projectRepository.GetById(model.projectId);
            _taskRepository.Update(model.Task);
            _taskRepository.Save();
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
