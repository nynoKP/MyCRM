using Microsoft.AspNetCore.Mvc;
using MyCRM.Data;
using MyCRM.Filters;
using MyCRM.Repository;

namespace MyCRM.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserRepository _userRepository;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
            _userRepository = new UserRepository(context);
        }

        public IActionResult AllTasks([FromForm] PaginationFilter filter)
        {
            return View();
        }

        public IActionResult MyTasks([FromForm] PaginationFilter filter)
        {
            return View();
        }

        public IActionResult UserTasks([FromForm] PaginationFilter filter, string executorId)
        {
            return View();
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
