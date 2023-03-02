using Microsoft.AspNetCore.Mvc;

namespace MyCRM.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
