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
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ProjectRepository projectRepository;
        private readonly ContragentRepository contragentRepository;
        private readonly UserRepository userRepository;

        public ProjectController(ApplicationDbContext context)
        {
            this.context = context;
            projectRepository = new ProjectRepository(context);
            contragentRepository = new ContragentRepository(context);
            userRepository = new UserRepository(context);
        }
        public IActionResult Index(int page = 1)
        {
            var filter = new PaginationFilter(projectRepository.Count(), page);
            var viewModel = new ProjectViewModel()
            {
                PaginationFilter = filter,
                Projects = projectRepository.GetAll(filter)
            };
            return View(viewModel);
        }

        public IActionResult Add()
        {
            var viewModel = new ProjectCreateViewModel()
            {
                Contragents = contragentRepository.GetAllWithoutPagination(),
                Users = userRepository.GetAll()
            };
            return View(viewModel);
        }

        public IActionResult Watch(int id)
        {
            return View(projectRepository.GetById(id));
        }

        public IActionResult Edit(int id)
        {
            var viewModel = new ProjectCreateViewModel()
            {
                Contragents = contragentRepository.GetAllWithoutPagination(),
                Users = userRepository.GetAll(),
                EditProject = projectRepository.GetById(id)
            };
            return View(viewModel);
        }

        public IActionResult Update(Project project,string userId, int customerId, string creatorId)
        {
            project.Creator = userRepository.GetById(creatorId);
            project.Responsible = userRepository.GetById(userId);
            project.Customer = contragentRepository.GetById(customerId);
            projectRepository.Update(project);
            projectRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Create([FromForm] Project project, string userId, int customerId)
        {
            project.Creator = userRepository.GetById(GetUserId());
            project.Responsible = userRepository.GetById(userId);
            project.Customer = contragentRepository.GetById(customerId);
            projectRepository.Add(project);
            projectRepository.Save();
            return RedirectToAction("Index");
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
