using Microsoft.AspNetCore.Mvc;

namespace MyCRM.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
