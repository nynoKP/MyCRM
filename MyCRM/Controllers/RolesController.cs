using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCRM.Interface.Service;
using MyCRM.Migrations;

namespace MyCRM.Controllers
{
    public class RolesController : Controller
    {
        private readonly IServiceManager _service;
        public RolesController(IServiceManager _service)
        {
            this._service = _service;
        }

        [Authorize(Roles = "Admin,IndexRoles")]
        public IActionResult Index()
        {
            return View(_service.Roles.GetAll());
        }

        [Authorize(Roles = "Admin,SyncRoles")]
        public IActionResult Sync()
        {
            _service.Roles.Sync();
            return RedirectToAction("Index");
        }
    }
}
